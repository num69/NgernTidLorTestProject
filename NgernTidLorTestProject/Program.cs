// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NgernTidLorTestProject;
using System.Diagnostics;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ExpressionEvaluator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Calculator API",
        Version = "v1",
        Description = "Simple .NET 8 Calculator API"
    });
});

WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator API v1");
    c.RoutePrefix = string.Empty;
});

app.MapPost("/calculator", (CalculatorBody req, ExpressionEvaluator evaluator) =>
{
    try
    {
        var result = evaluator.Evaluate(req.Expression);
        //var useCompute = Convert.ToDouble(new DataTable().Compute(req.Expression, ""));
        return Results.Ok(new { result });
    }
    catch (DivideByZeroException)
    {
        return Results.BadRequest(new { error = "Division by zero" });
    }
    catch (ArgumentException e)
    {
        Debug.Write(e.Message);
        return Results.BadRequest(new { error = "Invalid expression" });
    }
});


app.Run();

record CalculatorBody(string Expression);

