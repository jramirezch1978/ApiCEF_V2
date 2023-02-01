using System;
using AutoMapper;
using Intercorp.CEFReports.Domain.Entity;
using Intercorp.CEFReports.Application.DTO;

namespace Intercorp.CEFReports.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();

            CreateMap<Proyeccion, ProyeccionDTO>().ReverseMap();
            CreateMap<ProyeccionRequest, ProyeccionRequestDTO>().ReverseMap();
            CreateMap<ProyeccionDetalle, ProyeccionDetalleDTO>().ReverseMap();

            CreateMap<ReconciliacionPatrimonioRequest, ReconciliacionPatrimonioRequestDTO>().ReverseMap();
            CreateMap<ReconciliacionPatrimonio, ReconciliacionPatrimonioDTO>().ReverseMap();
        }
    }
}
