using System;
using System.Collections.Generic;
using System.Text;

namespace Intercorp.CEFReports.Domain.Entity
{
    public class CuentaAnalisisRequest
    {
        public int CODMETODIZADO { get; set; }
        public string ARGPERIODOS { get; set; }
        public string ARGPERPROY { get; set; }
        public int ARGCODANALISIS { get; set; }
        public int ARGCODEEFF { get; set; }
    }
}