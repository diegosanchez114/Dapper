//string apellido = "sanchez";

//var apellidoEnMayusculas = apellido.ToUpper();

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MinimalAPIPeliculas.Entidades;

var builder = WebApplication.CreateBuilder(args);

var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!;

//Creacion de los servicios
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });

    opciones.AddPolicy("libre", configuracion =>
    {
        configuracion.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddOutputCache();
    







//Fin de creacion de los servicios
var app = builder.Build();

//Creacion de los middlewares
app.UseCors();

app.UseOutputCache();


app.MapGet("", [EnableCors(policyName: "libre")]() => "Hola Diego Sanchez");

app.MapGet("/generos", () =>
{
    var generos = new List<Genero>
    {
        new Genero
        {
            Id= 1,
            Nombre= "Accion"
        },
        new Genero
        {
            Id= 2,
            Nombre= "Drama"
        },
        new Genero
        {
            Id= 3,
            Nombre= "Comedia"
        },

    };

    return generos;
}).CacheOutput(c => c.Expire(TimeSpan.FromSeconds(15)));

app.Run();
