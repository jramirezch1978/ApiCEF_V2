using System;
using System.Collections.Generic;
using System.Text;
using Intercorp.CEFReports.Transversal.Common;
using Intercorp.CEFReports.Application.DTO;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Application.Interface
{
    public interface IReconciliacionPatrimonioApplication
    {
        Task<Response<ReconciliacionPatrimonioDTO>> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequestDTO request);
        Task<Response<String>> ObtenerReconciliacionPatrimonioPDF(ReconciliacionPatrimonioRequestDTO request);
    }
}
