using System;
using System.Collections.Generic;
using System.Text;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Application.DTO;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Interface
{
    public interface IFuentesUsosFondosApplication
    {
        Task<Response<CuentaAnalisisDTO>> ObtenerFuentesUsosFondos(CuentaAnalisisRequestDTO request);
        Task<Response<String>> ObtenerFuentesUsosFondosPDF(CuentaAnalisisRequestDTO request);
    }
}
