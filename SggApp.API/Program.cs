using SggApp.DAL.Repositorios;
using SggApp.BLL.Interfaces;
using SggApp.BLL.Servicios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

var builder = WebApplication.CreateBuilder(args);
// Agregar DbContext con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"
)));
var app = builder.Build();
app.MapControllers();
app.Run();

//Registra capa de presentacion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"
)));

// Ejemplo de registros en Program.cs
var builder = WebApplication.CreateBuilder(args);
// ... (Registro de DbContext) ...
// Registrar Repositorios (DAL)
builder.Services.AddScoped<UsuarioRepository>();
// Acá los demás ...
// Registrar Servicios (BLL)
builder.Services.AddScoped<UsuarioRepository>();
// ... registrar GastoRepository, CategoriaRepository, MonedaRepository, PresupuestoRepository ...

// Registrar Servicios (BLL) - Igual que antes
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
// ... registrar IGastoService, ICategoriaService, IMonedaService,IPresupuestoService ...

// ... (AddControllers, Swagger, Autenticación/Autorización, CORS, etc.) ...
var app = builder.Build();
// ... (Configuración del pipeline HTTP: UseCors, UseAuthentication,UseAuthorization, MapControllers, etc.) ...

// Registro de repositorios (DAL)
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<GastoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<MonedaRepository>();
builder.Services.AddScoped<PresupuestoRepository>();

// Registro de servicios (BLL)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();

// Otros servicios del framework
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware estándar
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



app.Run();

