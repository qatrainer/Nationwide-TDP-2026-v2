// NW TDP 2026 v2
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));
app.MapPost("/calculate", (CalculateRequest request) =>
{
    if (request.Spending is null || request.Spending.Count == 0 || request.Spending.Any(x => x.Amount < 0))
        return Results.BadRequest(new { error = "Provide at least one spending item with a non-negative amount." });

    // Placeholder only: replace with database-backed emissions factors in Sprint 2.
    var breakdown = request.Spending.Select(x => new { category = x.Category, amount = x.Amount, carbonKg = 0m }).ToArray();
    return Results.Ok(new { status = "success", totalCarbonKg = 0m, breakdown, recommendations = Array.Empty<string>() });
});
app.Run();

public record CalculateRequest(List<SpendingItem>? Spending);
public record SpendingItem(string Category, decimal Amount);
public partial class Program { }
