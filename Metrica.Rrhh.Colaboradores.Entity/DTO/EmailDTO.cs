using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.DTO
{
    public class EmailDTO
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string RutaAdjunto { get; set; }
        public TipoMensaje TipoEmail { get; set; }
    }

    public enum TipoMensaje
    {
        Requerimiento,
        NuevoCandidato,
        FirmaContrato
    }
}
