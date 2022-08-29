using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Util
{
    public sealed class ConnectionUtil
    {
        private readonly string connectionString = null;
        private ConnectionUtil()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetConnectionString("Default");
        }
        private static ConnectionUtil Connection = new ConnectionUtil();
        public static ConnectionUtil GetInstance()
        {
            return ConnectionUtil.Connection;
        }
        public string GetConnectionString()
        {
            return this.connectionString;
        }
    }
}
