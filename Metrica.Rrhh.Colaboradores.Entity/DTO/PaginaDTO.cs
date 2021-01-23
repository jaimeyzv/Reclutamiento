using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class PaginaDTO
    {
        public int IdPagina { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public int IdPaginaPadre { get; set; }
        public string Icono { get; set; }
    }
}
