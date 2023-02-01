using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Intercorp.CEFReports.Domain.Entity;

namespace Intercorp.CEFReports.Domain.Interface
{
    public interface IProyeccionDomain
    {
        Task<Proyeccion> ObtenerProyeccion(ProyeccionRequest request);
            
    }
}
