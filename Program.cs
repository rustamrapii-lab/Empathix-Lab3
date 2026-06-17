using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapPost("/api/process", (TextRequest req) => {
    try {
        var session = new GenerationSession(req.Tone);
        var result = session.ProcessText(req.Text);
        return Results.Ok(new { result = result });
    }
    catch (Exception ex) {
        return Results.BadRequest(new { error = ex.Message });
    }
});
app.Run();
public record TextRequest(string Tone, string Text);