using FluentValidation;
using FluentValidation.Results;
using HyperTextExpression;
using HyperTextExpression.AspNetCore;

namespace Htmxin.Endpoints.Samples;

[Sample("/register/view", "Registration Screen")]
public class Registration
{
    public static IResult App() =>
        HtmlDoc(
            Head(("title", "Todo App!")),
            Body(
                RenderForm(null),
                HtmxScript,
                HtmxJsonEncScript
            )
        ).ToIResult();

    private static HtmlEl RenderForm(
        Form? form,
        IDictionary<string, string[]>? errors = null
    ) =>
        ("form",
            Attrs(
                "hx-post", "/register/form",
                "hx-ext", "json-enc",
                "hx-target", "this",
                "hx-swap", "innerHTML"
            ),
            Children(
                RenderInput("Username: ", "Username", Attrs("value", form?.Username ?? ""), errors.GetErrors("Username")),
                RenderInput(
                    "Password: ",
                    "Password",
                    Attrs("type", "password",
                        "hx-post", "/register/validate-pwd",
                        "hx-trigger", "keyup changed delay:500ms",
                        "hx-swap", "none"
                    ),
                    errors.GetErrors("Password")
                ),
                RenderInput(
                    "Confirm Password: ",
                    "ConfirmPassword",
                    Attrs("type", "password",
                        "hx-post", "/register/validate-pwd",
                        "hx-trigger", "keyup changed delay:500ms",
                        "hx-swap", "none"
                    ),
                    errors.GetErrors("ConfirmPassword")
                ),
                ("button", Attrs("type", "submit"), "Sign Up")
            )
        );

    private static HtmlEl RenderInput(
        string label,
        string name,
        HtmlAttributes attributes,
        string[]? errors = null
    ) => Div(
        Div(
            ("label", label),
            ("input", attributes.Add(("name", name)))
        ),
        RenderValidationErrors(name, errors ?? Array.Empty<string>())
    );

    private static HtmlEl RenderValidationErrors(string name, string[] errors, HtmlAttributes? attributes = null) =>
        ("ul",
            Attrs("id", $"validation-errors-{name}", "style", "margin: 0px").Concat(attributes),
            errors.Select(x => ("li", Attrs("style", "color: red;font-size: 11px;"), x))
        );

    public static IResult Submit(Form form)
    {
        var validation = new Form.Validation();
        var validationResult = validation.Validate(form);
        if (validationResult.IsValid)
        {
            return Div(("h2", "Signed up, please confirm your email."))
                .ToIResult();
        }

        return RenderForm(form, validationResult.ToDictionary())
            .ToIResult();
    }

    public static IResult ValidatePassword(Form form)
    {
        var validation = new Form.Validation();
        var validationResult = validation.Validate(form, o =>
        {
            o.IncludeProperties(nameof(Form.Password));
            o.IncludeProperties(nameof(Form.ConfirmPassword));
        });

        if (form.Password.ToLower().Equals("1234qwer"))
        {
            validationResult.Errors.Add(new ValidationFailure(nameof(Form.Password), "Password is too recognizable."));
        }

        var errors = validationResult.ToDictionary();

        return Children(
            RenderValidationErrors(
                nameof(Form.Password),
                errors.GetErrors(nameof(Form.Password)),
                Attrs("hx-swap-oob", "true")
            ),
            RenderValidationErrors(
                nameof(Form.ConfirmPassword),
                errors.GetErrors(nameof(Form.ConfirmPassword)),
                Attrs("hx-swap-oob", "true")
            )
        ).ToIResult();
    }

    public record Form(string Username, string Password, string ConfirmPassword)
    {
        public class Validation : AbstractValidator<Form>
        {
            public Validation()
            {
                RuleFor(x => x.Username)
                    .NotEmpty();

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .MinimumLength(8)
                    .Must(x => x.Any(char.IsUpper)).WithMessage("Must contain uppercase character.")
                    .Must(x => x.Any(char.IsDigit)).WithMessage("Must contain a digit.");

                RuleFor(x => x.ConfirmPassword)
                    .NotEmpty()
                    .Must((f, x) => f.Password == x).WithMessage("Must match Password");
            }
        }
    }
}

public static class DictionaryExt
{
    public static string[] GetErrors(this IDictionary<string, string[]>? dict, string key)
    {
        return dict?.TryGetValue(key, out var value) ?? false ? value : Array.Empty<string>();
    }
}