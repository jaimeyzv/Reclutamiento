﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Metrica.Rrhh.Colaboradores.BL.WSNotificacion {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultDTO", Namespace="http://schemas.datacontract.org/2004/07/Metrica.Rrhh.Colaboradores.Service.Extens" +
        "ion")]
    [System.SerializableAttribute()]
    public partial class FaultDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaultDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaultIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultDescription {
            get {
                return this.FaultDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.FaultDescriptionField, value) != true)) {
                    this.FaultDescriptionField = value;
                    this.RaisePropertyChanged("FaultDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultId {
            get {
                return this.FaultIdField;
            }
            set {
                if ((object.ReferenceEquals(this.FaultIdField, value) != true)) {
                    this.FaultIdField = value;
                    this.RaisePropertyChanged("FaultId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://MetricaAndina/Colaboradores/INotificacionService", ConfigurationName="WSNotificacion.INotificacionService")]
    public interface INotificacionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmail", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Metrica.Rrhh.Colaboradores.BL.WSNotificacion.FaultDTO), Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailFaultDTOFault", Name="FaultDTO", Namespace="http://schemas.datacontract.org/2004/07/Metrica.Rrhh.Colaboradores.Service.Extens" +
            "ion")]
        void EnviarEmail(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmail", ReplyAction="http://MetricaAndina/Colaboradores/INotificacionService/INotificacionService/Envi" +
            "arEmailResponse")]
        System.Threading.Tasks.Task EnviarEmailAsync(Metrica.Rrhh.Colaboradores.Entity.DTO.EmailDTO entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INotificacionServiceChannel : Metrica.Rrhh.Colaboradores.BL.WSNotificacion.INotificacionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NotificacionServiceClient : System.ServiceModel.ClientBase<Metrica.Rrhh.Colaboradores.BL.WSNotificacion.INotificacionService>, Metrica.Rrhh.Colaboradores.BL.WSNotificacion.INotificacionService {
        
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
    }
}
