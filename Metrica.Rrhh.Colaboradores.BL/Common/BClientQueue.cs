using IronSharp.Core;
using IronSharp.IronMQ;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.BL.Common
{
    public class BClientQueue
    {
        static IronMqRestClient mqCliente = Client.New(new IronClientConfig { ProjectId = "5b3982a0233642000a109578", Token = "Z5ZwpKCKSVuMmc6AW4C3", Host = "mq-aws-eu-west-1-1.iron.io", Scheme = "http", Port = 80 });
        QueueClient queue = mqCliente.Queue("metrica_rrhh");

        protected string RegistrarEmailQueue(EmailDTO dto)
        {
            return queue.Post(dto);
        }

        protected List<EmailDTO> ListarEmailQueue()
        {
            List<EmailDTO> retval = new List<EmailDTO>();
            int ? nMsg = queue.Info().Size;
            nMsg = nMsg == null ? 0 : nMsg;
            QueueMessage msg;
            for (int i = 0; i < nMsg; i++)
            {
                msg = queue.Reserve();
                retval.Add(JSON.Parse<EmailDTO>(msg.Body));
                msg.Delete();
                msg.Release();
            }
            return retval;
        }
    }
}
