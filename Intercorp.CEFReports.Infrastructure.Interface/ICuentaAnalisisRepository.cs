using Intercorp.CEFReports.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Infrastructure.Interface
{
    public interface ICuentaAnalisisRepository
    {
        Task<CuentaAnalisis> ObtenerCuentaAnalisis(CuentaAnalisisRequest request);
        Task<IEnumerable<CuentaAnalisisDetalle>> ListarCuentaAnalisisDetalle(int codMetodizado, string metodizadoXml, int CodAnalisis, int CodEEF);
    }
}
