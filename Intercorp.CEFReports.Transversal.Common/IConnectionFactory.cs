using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Intercorp.CEFReports.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetIBCefSqlConnection { get; }
        IDbConnection GetMysqlConnection { get; }
    }
}
