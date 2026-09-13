var builder = WebApplication.CreateBuilder(args);

// Inyecta YARP leyendo la sección "ReverseProxy" del appsettings
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Activa el middleware que intercepta y redirige el tráfico
app.MapReverseProxy();

app.Run();