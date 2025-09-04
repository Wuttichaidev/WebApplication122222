var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection(); 
 
app.UseAuthorization();
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        var headers = context.Response.Headers;

        if (!headers.ContainsKey("X-Content-Type-Options"))
            headers.Add("X-Content-Type-Options", "nosniff");

        if (!headers.ContainsKey("Cross-Origin-Resource-Policy"))
            headers.Add("Cross-Origin-Resource-Policy", "same-origin");

        return Task.CompletedTask;
    });

    await next();
});

app.MapControllers();

// Fix for CS4014: Await the RunAsync call in an async Main method
await app.RunAsync();
 