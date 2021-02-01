using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class ClienteModel : BaseModel
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string EmailContacto { get; set; }
        public string Estado { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return RazonSocial;
        }
    }
}
