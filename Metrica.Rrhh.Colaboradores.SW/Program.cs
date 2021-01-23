using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.SW
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            
#if (DEBUG)
            ServiceQueue sw = new ServiceQueue();
            sw.Start();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceQueue()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
