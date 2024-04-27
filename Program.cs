var builder = WebApplication.CreateBuilder(args);
//test
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Correctly configure CORS before building the app/
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policyBuilder => {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

var app = builder.Build();
//test
// Use CORS with the configured policy
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT: UseStaticFiles must be called before the endpoints are defined
app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });
app.UseStaticFiles(); // Enables serving static files from the wwwroot folder



// Continue with the configuration of your HTTP request pipeline as before

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

