using Metrica.Rrhh.Colaboradores.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Entity.Model
{
    public class RequerimientoModel: BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Perfil { get; set; }
        public ClienteModel Cliente { get; set; }
        public string Estado { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha Posible Ingreso")]
        public DateTime FechaTentativa { get; set; }
        [Required]
        [Display(Name = "Rango Salarial")]
        public string RangoSalario { get; set; }
        [Required]
        [Display(Name = "Descripción del Perfil")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Orden de Compra")]
        public string OrdenCompra { get; set; }
        public List<PostulanteModel> Postulaciones { get; set; }
    }
}
