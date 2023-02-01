using System;
using System.Collections.Generic;
using System.Text;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Application.DTO;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Interface
{
    public interface IProyeccionApplication
    {
        Task<Response<ProyeccionDTO>> ObtenerProyeccion(ProyeccionRequestDTO request);
        Task<Response<String>> ObtenerProyeccionPDF(ProyeccionRequestDTO request);
    }
}
