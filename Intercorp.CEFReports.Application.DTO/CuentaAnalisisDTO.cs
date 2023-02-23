using System;
using System.Collections.Generic;

namespace Intercorp.CEFReports.Application.DTO
{
    public class CuentaAnalisisDTO
    {
        public int CodPeriodo1 { get; set; }
        public string FecPeriodo1 { get; set; }
        public string Descripcion1 { get; set; }
        public int CodPeriodo2 { get; set; }
        public string FecPeriodo2 { get; set; }
        public string Descripcion2 { get; set; }
        public int CodPeriodo3 { get; set; }
        public string FecPeriodo3 { get; set; }
        public string Descripcion3 { get; set; }
        public int CodPeriodo4 { get; set; }
        public string FecPeriodo4 { get; set; }
        public string Descripcion4 { get; set; }
        public int CodPeriodo5 { get; set; }
        public string FecPeriodo5 { get; set; }
        public string Descripcion5 { get; set; }
        public string Auditores { get; set; }
        public string RazonSocial { get; set; }
        public string CifrasEn { get; set; }
        public string CUCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodAnalista { get; set; }
        public string NombreAnalista { get; set; }
        public string CodUsuValida { get; set; }
        public string NomUsuValida { get; set; }
        public string Estado { get; set; }
        public string Estado1 { get; set; }
        public string Estado2 { get; set; }
        public string Estado3 { get; set; }
        public string Estado4 { get; set; }
        public string Estado5 { get; set; }
        public string TipoCambio { get; set; }
        public string CodMoneda { get; set; }
        public List<CuentaAnalisisDetalleDTO> CuentaAnalisisDetalle { get; set; }


    }
}
