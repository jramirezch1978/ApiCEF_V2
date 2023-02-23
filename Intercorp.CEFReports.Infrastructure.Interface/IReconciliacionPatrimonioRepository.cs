using Intercorp.CEFReports.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Infrastructure.Interface
{
    public interface IReconciliacionPatrimonioRepository
    {
        Task<ReconciliacionPatrimonio> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequest request);
    }
}
