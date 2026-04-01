var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ✅ ADD HERE
app.UseStaticFiles();

// (optional but recommended)
app.UseDefaultFiles();

app.MapControllers();

app.Run();