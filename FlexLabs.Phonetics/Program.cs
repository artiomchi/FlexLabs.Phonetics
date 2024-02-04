using FlexLabs.Phonetics;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Map("/ph", ma => ma.UseMiddleware<PhoneticsMiddleware>());

app.Run();