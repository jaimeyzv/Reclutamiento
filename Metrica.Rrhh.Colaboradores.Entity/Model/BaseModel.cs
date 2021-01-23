using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class BaseModel
    {
        public int Accion { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UsuarioCreacion {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FechaCreacion { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UsuarioModificacion { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaModificacion { get; set; }
    }
}
