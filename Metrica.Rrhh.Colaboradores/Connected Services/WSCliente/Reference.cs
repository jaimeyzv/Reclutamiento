﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metrica.Rrhh.Colaboradores.WSCliente {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://MetricaAndina/Colaboradores/IClienteService", ConfigurationName="WSCliente.IClienteService")]
    public interface IClienteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/IClienteService/IClienteService/Listar", ReplyAction="http://MetricaAndina/Colaboradores/IClienteService/IClienteService/ListarResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(Metrica.Rrhh.Colaboradores.BL.WSNotificacion.FaultDTO), Action="http://MetricaAndina/Colaboradores/IClienteService/IClienteService/ListarFaultDTO" +
            "Fault", Name="FaultDTO", Namespace="http://schemas.datacontract.org/2004/07/Metrica.Rrhh.Colaboradores.Service.Extens" +
            "ion")]
        System.Collections.Generic.List<Metrica.Rrhh.Colaboradores.Entity.DTO.ClienteDTO> Listar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/IClienteService/IClienteService/Listar", ReplyAction="http://MetricaAndina/Colaboradores/IClienteService/IClienteService/ListarResponse" +
            "")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Metrica.Rrhh.Colaboradores.Entity.DTO.ClienteDTO>> ListarAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClienteServiceChannel : Metrica.Rrhh.Colaboradores.WSCliente.IClienteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClienteServiceClient : System.ServiceModel.ClientBase<Metrica.Rrhh.Colaboradores.WSCliente.IClienteService>, Metrica.Rrhh.Colaboradores.WSCliente.IClienteService {
        
        public ClienteServiceClient() {
        }
        
        public ClienteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Metrica.Rrhh.Colaboradores.Entity.DTO.ClienteDTO> Listar() {
            return base.Channel.Listar();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Metrica.Rrhh.Colaboradores.Entity.DTO.ClienteDTO>> ListarAsync() {
            return base.Channel.ListarAsync();
        }
    }
}
