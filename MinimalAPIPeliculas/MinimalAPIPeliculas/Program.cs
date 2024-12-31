//string apellido = "sanchez";

//var apellidoEnMayusculas = apellido.ToUpper();

using Microsoft.AspNetCore.Mvc.ModelBinding;
using MinimalAPIPeliculas.Entidades;

var builder = WebApplication.CreateBuilder(args);

var apellido = builder.Configuration.GetValue<string>("apellido");
var app = builder.Build();



app.MapGet("/", () => apellido);
app.MapGet("/otra", () => "Hola Diego Sanchez");

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
});

app.Run();
