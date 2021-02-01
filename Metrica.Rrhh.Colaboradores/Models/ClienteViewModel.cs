using Metrica.Rrhh.Colaboradores.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.Models
{
    public class ClienteViewModel : ClienteModel
    {
        [Required]
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public List<ClienteModel> Clientes { get; set; }
        public List<CandidatoModel> Candidatos { get; set; }
        public List<ItemModel> Estados { get; set; }
        public ClienteViewModel()
        {

        }

        public ClienteViewModel(ClienteModel eBase)
        {
            Id = eBase.Id;
            Ruc = eBase.Ruc;
            RazonSocial = eBase.RazonSocial;

            Direccion = eBase.Direccion;
            Telefono = eBase.Telefono;
            Contacto = eBase.Contacto;
            TelefonoContacto = eBase.TelefonoContacto;
            EmailContacto = eBase.EmailContacto;
        
        }
    }
}