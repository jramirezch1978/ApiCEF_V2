
using SelectPdf;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Intercorp.CEFReports.Domain.Entity;



namespace Intercorp.CEFReports.Transversal.Common
{
    public class SlipPDFHelper
    {
        public string FormatoFecha(string fecha)
        {
            var fechaRescate = $"01/{fecha.Replace("-", "/")}";
            return Convert.ToDateTime(fechaRescate, new System.Globalization.CultureInfo("es-PE")).ToString("MM/yy");
        }
        public string ClaseCelda(string fecha)
        {
            var fechaRescate = fecha.Split("-");
            var anioRescate = int.Parse(fechaRescate[1]);
            if ((anioRescate % 2) == 0)
            {
                return "color-celda";
            }
            else
            {
                return "";
            }
        }
        public decimal ValorDecimal(string prima, int decimales = 2)
        {
            var valor = Convert.ToDecimal(prima, new System.Globalization.CultureInfo("es-PE"));
            var resultado = Math.Round(valor, decimales, MidpointRounding.AwayFromZero);
            return resultado;
        }
        public byte[] GenerarSLIP(object slip, string htmlTemplate)
        {
            var sPDFPath = GetHtmlTemplatePath(htmlTemplate);
            byte[] retorno;
            string readText = string.Empty;
            try
            {
                string htmlStringSlip = GeneracionHtmlSlip(slip, htmlTemplate);
                HtmlToPdf converter = new HtmlToPdf();
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageCustomSize = new SizeF { Width = 550, Height = 800 };
                converter.Options.PdfPageOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), "Portrait", true);
                converter.Options.WebPageWidth = 800;
                converter.Options.WebPageHeight = 700;

                var doc1 = converter.ConvertHtmlString(htmlStringSlip, sPDFPath);
                PdfDocument doc = new PdfDocument();
                doc.Append(doc1);


                retorno = doc.Save();
            }
            catch (Exception ex)
            {
                return null;
            }

            return retorno;
        }
        private string GeneracionHtmlSlip(object slip, string htmlTemplate)
        {
            string htmlStringSlip = string.Empty;
            switch (htmlTemplate) 
            {
                case "Proyeccion":
                    htmlStringSlip = GetHtmlProyeccion((Proyeccion)slip);
                    break;
                case "ReconciliacionPatrimonio":
                    htmlStringSlip = GetHtmlReconciliacionPatrimonio((ReconciliacionPatrimonio)slip);
                    break;
                default:
                    htmlStringSlip = string.Empty;
                    break;
            }
            
            return htmlStringSlip;
        }
        public int DivideRoundingUp(int x, int y)
        {
            int remainder;
            int quotient = Math.DivRem(x, y, out remainder);
            return remainder == 0 ? quotient : quotient + 1;
        }
        string GetHtmlTemplateString(string path)
        {
            string readText = "";
            if (!File.Exists(path))
            {
                return string.Empty;
            }
            else
            {
                string appendText = "";
                File.AppendAllText(path, appendText, Encoding.UTF8);
                readText = File.ReadAllText(path);
            }
            return readText;
        }
        string GetHtmlTemplatePath(string path) {
            string tmplPath = string.Empty;
            tmplPath = Path.Combine((string)AppDomain.CurrentDomain.GetData("ContentRootPath"), "HtmlTemplates", path + ".html");
            return tmplPath;
        }

        public string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }
        public string Right(string value, int length)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length 
                ? value 
                : value.Substring(value.Length - length
                );
        }
        public string Left(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }
        //Proyecciones
        string GetHtmlProyeccion(Proyeccion proyeccion) 
        {
            string stringHtml = string.Empty;
            string htmlPath = GetHtmlTemplatePath("PlantillaProyecciones");
            string htmlPathDetail = GetHtmlTemplatePath("PlantillaProyeccionesDetalle");
            string hmtlString = GetHtmlTemplateString(htmlPath);
            string hmtlDetailString = GetHtmlTemplateString(htmlPathDetail);

            hmtlString = GetHtmlProyecccionCabecera(proyeccion, hmtlString);
            hmtlDetailString = GetHtmlProyecccionDetalle(proyeccion, hmtlDetailString);
            stringHtml = hmtlString.Replace("[rows]", hmtlDetailString);

            return stringHtml;
        }
        private string GetHtmlProyecccionCabecera(Proyeccion proyeccion, string readText)
        {
            string stringHtml = readText;

            stringHtml = stringHtml.Replace("[Titulo]", "PROYECCIONES");
            stringHtml = stringHtml.Replace("[TipoPer1]", NullToString(proyeccion.TIPOPER1));
            stringHtml = stringHtml.Replace("[EstadoFinanciero1]", NullToString(proyeccion.ESTADOFINANCIERO1));
            stringHtml = stringHtml.Replace("[Estado1]", NullToString(proyeccion.ESTADO1));
            stringHtml = stringHtml.Replace("[Fecha1]", NullToString(proyeccion.FECHA1));
            stringHtml = stringHtml.Replace("[TipoPer2]", NullToString(proyeccion.TIPOPER2));
            stringHtml = stringHtml.Replace("[EstadoFinanciero2]", NullToString(proyeccion.ESTADOFINANCIERO2));
            stringHtml = stringHtml.Replace("[Estado2]", NullToString(proyeccion.ESTADO2));
            stringHtml = stringHtml.Replace("[Fecha2]", NullToString(proyeccion.FECHA2));
            stringHtml = stringHtml.Replace("[TipoPer3]", NullToString(proyeccion.TIPOPER3));
            stringHtml = stringHtml.Replace("[EstadoFinanciero3]", NullToString(proyeccion.ESTADOFINANCIERO3));
            stringHtml = stringHtml.Replace("[Estado3]", NullToString(proyeccion.ESTADO3));
            stringHtml = stringHtml.Replace("[Fecha3]", NullToString(proyeccion.FECHA3));
            stringHtml = stringHtml.Replace("[TipoPer4]", NullToString(proyeccion.TIPOPER4));
            stringHtml = stringHtml.Replace("[EstadoFinanciero4]", NullToString(proyeccion.ESTADOFINANCIERO4));
            stringHtml = stringHtml.Replace("[Estado4]", NullToString(proyeccion.ESTADO4));
            stringHtml = stringHtml.Replace("[Fecha4]", NullToString(proyeccion.FECHA4));
            stringHtml = stringHtml.Replace("[ivar1]", Left(proyeccion.TIPOPER2, 1) + Right(proyeccion.FECHA2, 2) + " / " + Left(proyeccion.TIPOPER1, 1) + Right(proyeccion.FECHA1, 2));

            return stringHtml;
        }
        private string GetHtmlProyecccionDetalle(Proyeccion proyeccion, string readText)
        {
            string stringHtml = readText;
            var data = new StringBuilder();

            foreach (ProyeccionDetalle item in proyeccion.ProyeccionDetalle)
            {
                stringHtml = readText;
                stringHtml = stringHtml.Replace("[Descripcion]", item.DESCRIPCION.ToString());
                stringHtml = stringHtml.Replace("[Real1]", item.REAL1.ToString().ToString());
                stringHtml = stringHtml.Replace("[Vard1]", item.VAR1.ToString());
                stringHtml = stringHtml.Replace("[Proy1]", item.PROY1.ToString());
                stringHtml = stringHtml.Replace("[Vard2]", item.VAR2.ToString());
                stringHtml = stringHtml.Replace("[Real2]", item.REAL2.ToString());
                stringHtml = stringHtml.Replace("[Vard3]", item.VAR3.ToString());
                stringHtml = stringHtml.Replace("[Proy2]", item.PROY2.ToString());
                stringHtml = stringHtml.Replace("[Vard4]", item.VAR4.ToString());
                stringHtml = stringHtml.Replace("[Vara1]", item.VARA1.ToString());
                stringHtml = stringHtml.Replace("[Vara2]", item.VARA2.ToString());
                stringHtml = stringHtml.Replace("[Vara3]", item.VARA3.ToString());

                data.Append(stringHtml);
            }

            return data.ToString();
        }
        //ReconciliacionPatrimonioActivoFijo
        string GetHtmlReconciliacionPatrimonio(ReconciliacionPatrimonio reconciliacionPatrimonio)
        {
            string stringHtml = string.Empty;
            string htmlPath = GetHtmlTemplatePath("PlantillaReconciliacionPatrimonioActivoFijo");
            string htmlPathDetail = GetHtmlTemplatePath("PlantillaProyeccionesDetalle");
            string hmtlString = GetHtmlTemplateString(htmlPath);
            string hmtlDetailString = GetHtmlTemplateString(htmlPathDetail);

            hmtlString = GetHtmlReconciliacionPatrimonioCabecera(reconciliacionPatrimonio, hmtlString);
            hmtlDetailString = GetHtmlReconciliacionPatrimonioDetalle(reconciliacionPatrimonio, hmtlDetailString);
            stringHtml = hmtlString.Replace("[rows]", hmtlDetailString);

            return stringHtml;
        }
        private string GetHtmlReconciliacionPatrimonioCabecera(ReconciliacionPatrimonio reconciliacionPatrimonio, string readText)
        {
            string stringHtml = readText;

            stringHtml = stringHtml.Replace("[RazonSocial]", NullToString(reconciliacionPatrimonio.RazonSocial));
            stringHtml = stringHtml.Replace("[TipoDocumento]", NullToString(reconciliacionPatrimonio.TipoDocumento));
            stringHtml = stringHtml.Replace("[NumeroDocumento]", NullToString(reconciliacionPatrimonio.NumeroDocumento));
            stringHtml = stringHtml.Replace("[CifrasEn]", NullToString(reconciliacionPatrimonio.CifrasEn));
            stringHtml = stringHtml.Replace("[CUCliente]", NullToString(reconciliacionPatrimonio.CUCliente));
            stringHtml = stringHtml.Replace("[NombreAnalista]", NullToString(reconciliacionPatrimonio.NombreAnalista));
            stringHtml = stringHtml.Replace("[Auditores]", NullToString(reconciliacionPatrimonio.Auditores));
            stringHtml = stringHtml.Replace("[Descripcion1]", NullToString(reconciliacionPatrimonio.Descripcion1));
            stringHtml = stringHtml.Replace("[Estado1]", NullToString(reconciliacionPatrimonio.Estado1));
            stringHtml = stringHtml.Replace("[FecPeriodo1]", NullToString(reconciliacionPatrimonio.FecPeriodo1));
            stringHtml = stringHtml.Replace("[Descripcion2]", NullToString(reconciliacionPatrimonio.Descripcion2));
            stringHtml = stringHtml.Replace("[FecPeriodo2]", NullToString(reconciliacionPatrimonio.FecPeriodo2));
            stringHtml = stringHtml.Replace("[Descripcion3]", NullToString(reconciliacionPatrimonio.Descripcion3));
            stringHtml = stringHtml.Replace("[Estado3]", NullToString(reconciliacionPatrimonio.Estado3));
            stringHtml = stringHtml.Replace("[FecPeriodo3]", NullToString(reconciliacionPatrimonio.FecPeriodo3));
            stringHtml = stringHtml.Replace("[Descripcion5]", NullToString(reconciliacionPatrimonio.Descripcion5));
            stringHtml = stringHtml.Replace("[Estado5]", NullToString(reconciliacionPatrimonio.Estado5));
            stringHtml = stringHtml.Replace("[FecPeriodo5]", NullToString(reconciliacionPatrimonio.FecPeriodo5));

            return stringHtml;
        }
        private string GetHtmlReconciliacionPatrimonioDetalle(ReconciliacionPatrimonio reconciliacionPatrimonio, string readText)
        {
            string stringHtml = readText;
            var data = new StringBuilder();

            //foreach (ProyeccionDetalle item in proyeccion.ProyeccionDetalle)
            //{
            //    stringHtml = readText;
            //    stringHtml = stringHtml.Replace("[Descripcion]", item.DESCRIPCION.ToString());
            //    stringHtml = stringHtml.Replace("[Real1]", item.REAL1.ToString().ToString());
            //    stringHtml = stringHtml.Replace("[Vard1]", item.VAR1.ToString());
            //    stringHtml = stringHtml.Replace("[Proy1]", item.PROY1.ToString());
            //    stringHtml = stringHtml.Replace("[Vard2]", item.VAR2.ToString());
            //    stringHtml = stringHtml.Replace("[Real2]", item.REAL2.ToString());
            //    stringHtml = stringHtml.Replace("[Vard3]", item.VAR3.ToString());
            //    stringHtml = stringHtml.Replace("[Proy2]", item.PROY2.ToString());
            //    stringHtml = stringHtml.Replace("[Vard4]", item.VAR4.ToString());
            //    stringHtml = stringHtml.Replace("[Vara1]", item.VARA1.ToString());
            //    stringHtml = stringHtml.Replace("[Vara2]", item.VARA2.ToString());
            //    stringHtml = stringHtml.Replace("[Vara3]", item.VARA3.ToString());

            //    data.Append(stringHtml);
            //}

            return data.ToString();
        }
        //Notas
        string GetHtmlNotas(ReconciliacionPatrimonio reconciliacionPatrimonio)
        {
            string stringHtml = string.Empty;
            string htmlPath = GetHtmlTemplatePath("PlantillaReconciliacionPatrimonioActivoFijo");
            string htmlPathDetail = GetHtmlTemplatePath("PlantillaProyeccionesDetalle");
            string hmtlString = GetHtmlTemplateString(htmlPath);
            string hmtlDetailString = GetHtmlTemplateString(htmlPathDetail);

            hmtlString = GetHtmlReconciliacionPatrimonioCabecera(reconciliacionPatrimonio, hmtlString);
            hmtlDetailString = GetHtmlReconciliacionPatrimonioDetalle(reconciliacionPatrimonio, hmtlDetailString);
            stringHtml = hmtlString.Replace("[rows]", hmtlDetailString);

            return stringHtml;
        }
        private string GetHtmlNotas(ReconciliacionPatrimonio reconciliacionPatrimonio, string readText)
        {
            string stringHtml = readText;

            stringHtml = stringHtml.Replace("[RazonSocial]", NullToString(reconciliacionPatrimonio.RazonSocial));
            stringHtml = stringHtml.Replace("[TipoDocumento]", NullToString(reconciliacionPatrimonio.TipoDocumento));
            stringHtml = stringHtml.Replace("[NumeroDocumento]", NullToString(reconciliacionPatrimonio.NumeroDocumento));
            stringHtml = stringHtml.Replace("[CifrasEn]", NullToString(reconciliacionPatrimonio.CifrasEn));
            stringHtml = stringHtml.Replace("[CUCliente]", NullToString(reconciliacionPatrimonio.CUCliente));
            stringHtml = stringHtml.Replace("[NombreAnalista]", NullToString(reconciliacionPatrimonio.NombreAnalista));
            stringHtml = stringHtml.Replace("[Auditores]", NullToString(reconciliacionPatrimonio.Auditores));
            stringHtml = stringHtml.Replace("[Descripcion1]", NullToString(reconciliacionPatrimonio.Descripcion1));
            stringHtml = stringHtml.Replace("[Estado1]", NullToString(reconciliacionPatrimonio.Estado1));
            stringHtml = stringHtml.Replace("[FecPeriodo1]", NullToString(reconciliacionPatrimonio.FecPeriodo1));
            stringHtml = stringHtml.Replace("[Descripcion2]", NullToString(reconciliacionPatrimonio.Descripcion2));
            stringHtml = stringHtml.Replace("[FecPeriodo2]", NullToString(reconciliacionPatrimonio.FecPeriodo2));
            stringHtml = stringHtml.Replace("[Descripcion3]", NullToString(reconciliacionPatrimonio.Descripcion3));
            stringHtml = stringHtml.Replace("[Estado3]", NullToString(reconciliacionPatrimonio.Estado3));
            stringHtml = stringHtml.Replace("[FecPeriodo3]", NullToString(reconciliacionPatrimonio.FecPeriodo3));
            stringHtml = stringHtml.Replace("[Descripcion5]", NullToString(reconciliacionPatrimonio.Descripcion5));
            stringHtml = stringHtml.Replace("[Estado5]", NullToString(reconciliacionPatrimonio.Estado5));
            stringHtml = stringHtml.Replace("[FecPeriodo5]", NullToString(reconciliacionPatrimonio.FecPeriodo5));

            return stringHtml;
        }
        private string GetHtmlNotasDetalle(ReconciliacionPatrimonio reconciliacionPatrimonio, string readText)
        {
            string stringHtml = readText;
            var data = new StringBuilder();

            //foreach (ProyeccionDetalle item in proyeccion.ProyeccionDetalle)
            //{
            //    stringHtml = readText;
            //    stringHtml = stringHtml.Replace("[Descripcion]", item.DESCRIPCION.ToString());
            //    stringHtml = stringHtml.Replace("[Real1]", item.REAL1.ToString().ToString());
            //    stringHtml = stringHtml.Replace("[Vard1]", item.VAR1.ToString());
            //    stringHtml = stringHtml.Replace("[Proy1]", item.PROY1.ToString());
            //    stringHtml = stringHtml.Replace("[Vard2]", item.VAR2.ToString());
            //    stringHtml = stringHtml.Replace("[Real2]", item.REAL2.ToString());
            //    stringHtml = stringHtml.Replace("[Vard3]", item.VAR3.ToString());
            //    stringHtml = stringHtml.Replace("[Proy2]", item.PROY2.ToString());
            //    stringHtml = stringHtml.Replace("[Vard4]", item.VAR4.ToString());
            //    stringHtml = stringHtml.Replace("[Vara1]", item.VARA1.ToString());
            //    stringHtml = stringHtml.Replace("[Vara2]", item.VARA2.ToString());
            //    stringHtml = stringHtml.Replace("[Vara3]", item.VARA3.ToString());

            //    data.Append(stringHtml);
            //}

            return data.ToString();
        }
    }
}
