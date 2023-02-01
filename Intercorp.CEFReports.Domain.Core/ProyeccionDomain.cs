using System;
using Intercorp.CEFReports.Domain.Interface;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intercorp.CEFReports.Domain.Core
{
    public class ProyeccionDomain : IProyeccionDomain
    {
        private readonly IProyeccionRepository _ProyeccionRepository;

        public ProyeccionDomain(IProyeccionRepository proyeccionRepository)
        {
            _ProyeccionRepository = proyeccionRepository;
        }

        public async Task<Proyeccion> ObtenerProyeccion(ProyeccionRequest request)
        {
            return await _ProyeccionRepository.ObtenerProyeccion(request);

        }

    }
}
