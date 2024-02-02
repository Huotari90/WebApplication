var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint yhteenlaskulle
app.MapGet("/add", (double num1, double num2) => Results.Ok(new { Result = num1 + num2 }))
    .WithName("Add")
    .WithOpenApi();

// Endpoint vähennyslaskulle
app.MapGet("/subtract", (double num1, double num2) => Results.Ok(new { Result = num1 - num2 }))
    .WithName("Subtract")
    .WithOpenApi();

// Endpoint kertolaskulle
app.MapGet("/multiply", (double num1, double num2) => Results.Ok(new { Result = num1 * num2 }))
    .WithName("Multiply")
    .WithOpenApi();

// Endpoint jakolaskulle
app.MapGet("/divide", (double num1, double num2) => {
    if (num2 == 0) return Results.BadRequest("Nollalla jakaminen ei ole sallittua.");
    return Results.Ok(new { Result = num1 / num2 });
})
    .WithName("Divide")
    .WithOpenApi();

app.Run();