using System;
using System.Collections.Generic;
using System.Text;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Application.DTO;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Interface
{
    public interface IEstadoGananciaPerdidaApplication
    {
        Task<Response<CuentaAnalisisDTO>> ObtenerEstadoGananciaPerdida(CuentaAnalisisRequestDTO request);
        Task<Response<String>> ObtenerEstadoGananciaPerdidaPDF(CuentaAnalisisRequestDTO request);
    }
}
