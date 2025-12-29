var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapGet("/", (string? q) => Results.Extensions.RazorSlice<FlexLabs.Phonetics.Slices.Index, string?>(q));

app.Run();