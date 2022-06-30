using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaDeEscape.Models;
using System;
using System.Collections.Generic;

namespace SalaDeEscape.Controllers;

public class EscapeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public EscapeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Comenzar()
    {
        Escape.reiniciarJuego();
        ViewBag.SalaActual = 1;
        return View("Habitacion1");
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult Habitacion(int sala, string incognita)
    {
        bool resuelto=Escape.ResolverSala(sala,incognita);
        if ( resuelto == true && sala!=4)
        {
            sala = sala + 1;
            ViewBag.salaActual = Escape.EstadoJuego;
            return View("Habitacion" + Escape.EstadoJuego);
        }
        else if(resuelto && sala == 4)
        {
            return View("victoria");
        }
        else
        {
            bool condicionError = true;
            ViewBag.Error = condicionError;
            ViewBag.salaActual = Escape.EstadoJuego;
            return View("Habitacion" + Escape.EstadoJuego);
        }
    } 
    
}
