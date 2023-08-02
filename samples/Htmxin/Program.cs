using System.Text.Json;
using System.Text.Json.Serialization;
using Htmxin.Endpoints;
using Htmxin.Endpoints.Samples;

var builder = WebApplication.CreateBuilder(args);
TodoApp.RegisterServices(builder.Services);
builder.Services.ConfigureHttpJsonOptions(opts =>
{
    opts.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    opts.SerializerOptions.Converters.Add(new BooleanConverter());
});

var app = builder.Build();

app.MapGet("/", Home.Handle);

app.MapGet("/infinite-load", InfiniteLoad.Landing);
app.MapGet("/infinite-load/more", InfiniteLoad.LoadMore);

app.MapGet("/todo-app", TodoApp.App);
app.MapPost("/todo-app/add-todo", TodoApp.AddTodo);
app.MapPut("/todo-app/update-status", TodoApp.UpdateTodo);
app.MapDelete("/todo-app/delete-todo/{id:int}", TodoApp.DeleteTodo);

app.Run();

public class BooleanConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.String => reader.GetString() switch
            {
                "true" => true,
                "false" => false,
                _ => throw new JsonException()
            },
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }
}