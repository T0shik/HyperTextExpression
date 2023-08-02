using HyperTextExpression;
using HyperTextExpression.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Htmxin.Endpoints.Samples;

[Sample("/todo-app", "A simple todo app!")]
public class TodoApp
{
    public static IResult App(Todos todos) => HtmlDoc(
        Head(
            ("title", "Todo App!")
        ),
        Body(
            Div(
                Attrs("style", "max-width: 800px; margin: auto; margin-bottom: 5rem;"),
                ("h1", "My to do's"),
                Div(
                    Attrs("id", "todo-list"),
                    todos.Select(RenderTodo)
                ),
                Div(
                    HtmlEl("form",
                        ("h4", "Add Todo"),
                        ("input",
                            Attrs(
                                ("id", "todo-input"),
                                ("type", "text"),
                                ("name", "deed")
                            )
                        ),
                        ("button",
                            Attrs(
                                "hx-post", "/todo-app/add-todo",
                                "hx-ext", "json-enc",
                                "hx-target", "#todo-list",
                                "hx-on", "htmx:afterRequest: (document.getElementById('todo-input').value = '')"
                            ),
                            "add")
                    )
                )
            ),
            HtmxScript,
            HtmxJsonEncScript
        )
    ).ToIResult();

    private static HtmlEl RenderTodo(Todo todo, int index) =>
        HtmlEl("form",
            ("span", Children(
                ("strong", $"{todo.Id}.")
            )),
            ("input",
                Attrs(
                    ("type", "checkbox"),
                    (todo.Done ? "checked" : ""),
                    ("hx-put", "/todo-app/update-status"),
                    ("hx-ext", "json-enc"),
                    ("hx-target", "#todo-list")
                )
            ),
            ("input", Attrs(("type", "hidden"), ("name", "id"), ("value", todo.Id))),
            ("input", Attrs(("type", "hidden"), ("name", "value"), ("value", !todo.Done))),
            ("input", Attrs(("type", "hidden"), ("name", "pos"), ("value", index))),
            ("label",
                Attrs("style", todo.Done ? "text-decoration: line-through;" : ""),
                todo.Deed
            ),
            ("a",
                Attrs(
                    "hx-delete", $"/todo-app/delete-todo/{todo.Id}",
                    "hx-target", "#todo-list"
                ),
                "Delete"
            )
        );


    public record AddTodoCommand(string Deed);

    public static IResult AddTodo([FromBody] AddTodoCommand command, Todos todos)
    {
        todos.Add(command.Deed);
        return todos.Select(RenderTodo).ToIResult();
    }

    public record UpdateTodoCommand(int Id, int Pos, bool Value);

    public static IResult UpdateTodo([FromBody] UpdateTodoCommand command, Todos todos)
    {
        var todo = todos.FirstOrDefault(x => x.Id == command.Id);
        if (todo != null)
        {
            todos.Remove(todo);
            todos.Insert(command.Pos, todo with { Done = command.Value });
        }

        return todos.Select(RenderTodo).ToIResult();
    }

    public static IResult DeleteTodo(int id, Todos todos)
    {
        var todo = todos.FirstOrDefault(x => x.Id == id);
        if (todo != null)
        {
            todos.Remove(todo);
        }

        return todos.Select(RenderTodo).ToIResult();
    }


    public static IServiceCollection RegisterServices(IServiceCollection services) => services.AddSingleton<Todos>();

    public record Todo(int Id, string Deed, bool Done);

    public class Todos : List<Todo>
    {
        private int _idCount = 0;

        public Todos()
        {
            Add("Educate the masses.", true);
            Add("Fix HTML in .NET", true);
            Add("Learn HTMX");
            Add("Change underwear");
        }

        public void Add(string deed, bool done = false) => Add(new Todo(_idCount++, deed, done));
    }
}