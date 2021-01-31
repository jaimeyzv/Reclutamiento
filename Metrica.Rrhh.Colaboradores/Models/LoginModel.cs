using Metrica.Rrhh.Colaboradores.BL;
using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Metrica.Rrhh.Colaboradores.Models
{
    public class LoginModel
    {
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

}