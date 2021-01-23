using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.Common
{
    public class ServiceClientFactory<TChannel> : ClientBase<TChannel> where TChannel : class
    {
        public TChannel Create(string url)
        {
            Endpoint.Address = new EndpointAddress(new Uri(url));
            return Channel;
        }
    }
}