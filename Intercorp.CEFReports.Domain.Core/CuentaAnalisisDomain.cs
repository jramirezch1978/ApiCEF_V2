using System;
using Intercorp.CEFReports.Domain.Interface;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Domain.Core
{
    public class CuentaAnalisisDomain : ICuentaAnalisisDomain
    {
        private readonly ICuentaAnalisisRepository _CuentaAnalisisRepository;

        public CuentaAnalisisDomain(ICuentaAnalisisRepository CuentaAnalisisRepository)
        {
            _CuentaAnalisisRepository = CuentaAnalisisRepository;
        }

        public async Task<CuentaAnalisis> ObtenerCuentaAnalisis(CuentaAnalisisRequest request)
        {
            return await _CuentaAnalisisRepository.ObtenerCuentaAnalisis(request);

        }

    }
}
