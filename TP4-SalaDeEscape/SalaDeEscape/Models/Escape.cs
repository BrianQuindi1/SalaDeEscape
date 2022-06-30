using System;
using System.Collections.Generic;
namespace SalaDeEscape.Models;

public static class Escape
{
    private static List<string> _IncongnitasSalas = new List<string>();
    private static int _EstadoJuego = 1;

    public static int EstadoJuego
    {
        get
        {
            return _EstadoJuego;
        }
    }

    public static List<string> IncongnitasSalas
    {
        get
        {
            return _IncongnitasSalas;
        }
    }

    public static void reiniciarJuego()
      {
          _EstadoJuego = 1;
      }

    public static void inicializarLista()
    {
        _IncongnitasSalas.Insert(0,"fosiles");
        _IncongnitasSalas.Insert(1,"pez");
        _IncongnitasSalas.Insert(2,"gaviota");
        _IncongnitasSalas.Insert(3,"A");
    }

    public static bool ResolverSala(int Sala, string Incognita)
    {
        // inicializar las respuestas
       inicializarLista();
       if (_IncongnitasSalas[Sala-1] == Incognita)
       {
            _EstadoJuego = Sala + 1;
            return true;    
       } 
       else
       {
           return false;
       }
    }
}
