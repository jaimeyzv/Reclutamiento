using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.SW
{
    public partial class ServiceQueue : ServiceBase
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ServiceQueue));
        Thread thread;
        bool stopSignal;

        public ServiceQueue()
        {
            ServiceName = "METRICA - Servicio de mensajeria";
            EventLog.Log = "METRICA - RRHH Application";
            InitializeComponent();
            thread = null;
            stopSignal = false; //Señal desactivada, cuando sea True el hilo tomara la señal y se detendra.
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("Iniciando Servicio........");
            ThreadStart ts = new ThreadStart(ThreadExecution);
            thread = new Thread(ts);
            thread.Start();
        }

        protected override void OnStop()
        {
            logger.Info("Deteniendo Servicio........");
            stopSignal = true;
        }

        protected void ThreadExecution() // se ejecutara en paralelo con el servicio
        {
            logger.Info("======Servicio Iniciado Correctamente=======");
            while (!stopSignal)
            {
                ServiceManager serviceManager = new ServiceManager();
                serviceManager.Start();
#if (DEBUG)

                stopSignal = true;
#endif
            }
            logger.Info("======Servicio Detenido Correctamente=======");
            stopSignal = false;
        }
    }
}
