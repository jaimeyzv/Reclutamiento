using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.Service.Extension
{
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    public class ErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return false;
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error == null) return;
            log4net.ILog logger = log4net.LogManager.GetLogger("RecursosHumanosService");
            logger.Error(" *** Error Message : " + error.Message + " *** " + "\\n *** StackTrace : " + error.StackTrace + " *** ");
        }
    }

    [DataContract]
    public class FaultDTO
    {
        [DataMember]
        public string FaultId { get; set; }

        [DataMember]
        public string FaultDescription { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;
        public ServiceErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        #region IServiceBehavior Members
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler;
            errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;
                cd.ErrorHandlers.Add(errorHandler);
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // throw new NotImplementedException();
        }
        #endregion
    }
}
