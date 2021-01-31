using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.Models
{
    public class RequerimientoViewModel : RequerimientoModel
    {
        [Required]
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public List<ClienteModel> Clientes { get; set; }
        public List<CandidatoModel> Candidatos { get; set; }
        public List<ItemModel> Estados { get; set; }
        public RequerimientoViewModel()
        {

        }

        public RequerimientoViewModel(RequerimientoModel eBase)
        {
            Id = eBase.Id;
            Perfil = eBase.Perfil;
            Cliente = eBase.Cliente;
            IdCliente = Cliente != null ? Cliente.Id : 0;
            Estado = eBase.Estado;
            FechaTentativa = eBase.FechaTentativa;
            RangoSalario = eBase.RangoSalario;
            Descripcion = eBase.Descripcion;
            OrdenCompra = eBase.OrdenCompra;
            Postulaciones = eBase.Postulaciones;
            NombreCliente = Cliente != null ? Cliente.RazonSocial : "";
        }
    }
}