using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Interfaz
{
    public interface IDConsulta<T> where T : class
    {
        List<T> Listar();
        List<T> Listar(T entity);
        T Obtener(T entity);
    }
}
