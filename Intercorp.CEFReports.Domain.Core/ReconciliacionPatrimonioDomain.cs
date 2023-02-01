using System;
using Intercorp.CEFReports.Domain.Interface;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Domain.Core
{
    public class ReconciliacionPatrimonioDomain : IReconciliacionPatrimonioDomain
    {
        private readonly IReconciliacionPatrimonioRepository _reconciliacionPatrimonioRepository;

        public ReconciliacionPatrimonioDomain(IReconciliacionPatrimonioRepository reconciliacionPatrimonioRepository)
        {
            _reconciliacionPatrimonioRepository = reconciliacionPatrimonioRepository;
        }

        public async Task<ReconciliacionPatrimonio> ObtenerReconciliacionPatrimonio(ReconciliacionPatrimonioRequest request)
        {
            return await _reconciliacionPatrimonioRepository.ObtenerReconciliacionPatrimonio(request);

        }

    }
}
