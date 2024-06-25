using empresaimpresora;
using empresaimpresora.Middlewares;
using empresaimpresora.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbcontext>(opt => opt.UseSqlite("Data Source=midb.db"));
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IImpresoraService, ImpresoraService>();
//builder.Services.AddScoped<IHelloworldService, HelloworldService>();
//builder.Services.AddScoped<IHelloworldService>(p=> new HelloworldService());//esta forma de hacerlo podria agregarle parametros
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
