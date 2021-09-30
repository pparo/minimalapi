using MinimalApi.Data;
using MinimalApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new MyClass(Guid.NewGuid(), "Testando Minimal APIs")));

app.MapGet("/v1/classes", (AppDbContext context) =>
{
    var classes = context.MyClasses;
    return classes is not null ? Results.Ok(classes) : Results.NotFound();
}).Produces<MyClass>();

app.MapPost("/v1/class", (AppDbContext context, CreateClassViewModel model) =>
{
    var newClass = model.MapTo();
    
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.MyClasses.Add(newClass);
    context.SaveChanges();

    return Results.Created($"/v1/class/{newClass.Id}", newClass);
});


app.Run();