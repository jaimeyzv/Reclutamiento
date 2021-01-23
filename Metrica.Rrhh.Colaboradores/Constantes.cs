using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Metrica.Rrhh.Colaboradores
{
    public static class Constantes
    {
        public static string RutaRest = ConfigurationManager.AppSettings.Get("rutaRest");
        public static string RutaSoap = ConfigurationManager.AppSettings.Get("rutaSoap");
        public struct Estados
        {
            public const int Requerimiento = 1;
            public const int Postulante = 2;
        }
    }
}