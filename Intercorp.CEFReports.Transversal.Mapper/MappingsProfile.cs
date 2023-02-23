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
            CreateMap<ProyeccionDetalle, ProyeccionDetalleDTO>().ReverseMap();
            CreateMap<ProyeccionRequest, ProyeccionRequestDTO>().ReverseMap();

            CreateMap<ReconciliacionPatrimonio, ReconciliacionPatrimonioDTO>().ReverseMap();
            CreateMap<ReconciliacionPatrimonioRequest, ReconciliacionPatrimonioRequestDTO>().ReverseMap();

            CreateMap<CuentaAnalisis, CuentaAnalisisDTO>().ReverseMap();
            CreateMap<CuentaAnalisisDetalle, CuentaAnalisisDetalleDTO>().ReverseMap();
            CreateMap<CuentaAnalisisRequest, CuentaAnalisisRequestDTO>().ReverseMap();


        }
    }
}
