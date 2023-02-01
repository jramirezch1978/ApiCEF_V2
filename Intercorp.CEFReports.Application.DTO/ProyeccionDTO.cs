using System;
using System.Collections.Generic;

namespace Intercorp.CEFReports.Application.DTO
{
    public class ProyeccionDTO
    {
        public string TIPOPER1 { get; set; }
        public string ESTADOFINANCIERO1 { get; set; }
        public string ESTADO1 { get; set; }
        public string FECHA1 { get; set; }
        public string TIPOPER2 { get; set; }
        public string ESTADOFINANCIERO2 { get; set; }
        public string ESTADO2 { get; set; }
        public string FECHA2 { get; set; }
        public string TIPOPER3 { get; set; }
        public string ESTADOFINANCIERO3 { get; set; }
        public string ESTADO3 { get; set; }
        public string FECHA3 { get; set; }
        public string TIPOPER4 { get; set; }
        public string ESTADOFINANCIERO4 { get; set; }
        public string ESTADO4 { get; set; }
        public string FECHA4 { get; set; }
        public List<ProyeccionDetalleDTO> ProyeccionDetalle { get; set; }

    }
}
