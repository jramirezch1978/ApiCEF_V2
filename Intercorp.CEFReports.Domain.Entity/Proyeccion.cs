using System;
using System.Collections.Generic;
using System.Text;

namespace Intercorp.CEFReports.Domain.Entity
{
    public class Proyeccion
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
        public List<ProyeccionDetalle> ProyeccionDetalle { get; set; }
    }
}
