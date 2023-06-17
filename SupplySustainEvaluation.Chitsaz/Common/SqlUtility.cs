using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace SupplySustainEvaluation.Chitsaz.Common
{
    public interface ISqlUtility
    {
        SqlConnection GetNewConnection();
    }
    public class SqlUtility : ISqlUtility
    {
        IConfiguration Configuration;

        public SqlUtility(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public SqlConnection GetNewConnection()
        {
            var connectionString = Configuration.GetConnectionString("SupplySustainDB");
            var sc = new SqlConnection(connectionString);
            return sc;
        }
    }
}
