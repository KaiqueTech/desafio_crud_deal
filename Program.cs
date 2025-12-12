using System.Data;
using CursosApi.Data;
using CursosApi.Services.Alunos;
using CursosApi.Services.Cursos;
using CursosApi.Services.Matriculas;
using CursosApi.Services.Relatorios;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDbConnection>(con =>
{
    var connectionString = con.GetRequiredService<IConfiguration>()
                             .GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
