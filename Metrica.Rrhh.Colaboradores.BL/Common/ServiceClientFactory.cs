using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL.Common
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
