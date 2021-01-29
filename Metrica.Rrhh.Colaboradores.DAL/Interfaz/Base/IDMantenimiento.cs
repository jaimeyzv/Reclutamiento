using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrica.Rrhh.Colaboradores.DAL.Interfaz
{
    public interface IDMantenimiento<T, K> : IDConsulta<T> where T : class
    {
        K Insertar(T entity);
        K Actualizar(T entity);
        K Eliminar(T entity);
        K ActualizarEstado(T entity);
    }
}
