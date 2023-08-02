using Htmxin.Endpoints;
using Htmxin.Endpoints.Samples;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", Home.Handle);

app.MapGet("/infinite-load", InfiniteLoad.Landing);
app.MapGet("/infinite-load/more", InfiniteLoad.LoadMore);

app.Run();