﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using pruebaPuestoDGII.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar conexion a BBDD SQLite
var connectionString = builder.Configuration.GetConnectionString("Sqlite");

builder.Services.AddDbContext<DataContext>(
    Options => Options.UseSqlite(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

