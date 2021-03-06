﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metrica.Rrhh.Colaboradores.Test.WSNotificacion {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://MetricaAndina/Colaboradores/INotificacionService", ConfigurationName="WSNotificacion.INotificacionService")]
    public interface INotificacionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmail", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Metrica.Rrhh.Colaboradores.Service.Extension.FaultDTO), Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailFaultDTOFault", Name="FaultDTO", Namespace="http://schemas.datacontract.org/2004/07/Metrica.Rrhh.Colaboradores.Service.Extens" +
            "ion")]
        void EnviarEmail(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmail", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailResponse")]
        System.Threading.Tasks.Task EnviarEmailAsync(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailPendientesQueue", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailPendientesQueueResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Metrica.Rrhh.Colaboradores.Service.Extension.FaultDTO), Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailPendientesQueueFaultDTOFault", Name="FaultDTO", Namespace="http://schemas.datacontract.org/2004/07/Metrica.Rrhh.Colaboradores.Service.Extens" +
            "ion")]
        void EnviarEmailPendientesQueue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailPendientesQueue", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailPendientesQueueResponse")]
        System.Threading.Tasks.Task EnviarEmailPendientesQueueAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INotificacionServiceChannel : Metrica.Rrhh.Colaboradores.Test.WSNotificacion.INotificacionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NotificacionServiceClient : System.ServiceModel.ClientBase<Metrica.Rrhh.Colaboradores.Test.WSNotificacion.INotificacionService>, Metrica.Rrhh.Colaboradores.Test.WSNotificacion.INotificacionService {
        
        public NotificacionServiceClient() {
        }
        
        public NotificacionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NotificacionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotificacionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NotificacionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void EnviarEmail(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity) {
            base.Channel.EnviarEmail(entity);
        }
        
        public System.Threading.Tasks.Task EnviarEmailAsync(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity) {
            return base.Channel.EnviarEmailAsync(entity);
        }
        
        public void EnviarEmailPendientesQueue() {
            base.Channel.EnviarEmailPendientesQueue();
        }
        
        public System.Threading.Tasks.Task EnviarEmailPendientesQueueAsync() {
            return base.Channel.EnviarEmailPendientesQueueAsync();
        }
    }
}
