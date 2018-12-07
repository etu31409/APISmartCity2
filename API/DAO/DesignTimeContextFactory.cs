using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using APISmartCity.Model;

namespace APISmartCity.DAO
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<SCNConnectDBContext>
    {
        private const string CONNECTION_STRING_CONFIG_KEY = "Connection";
        readonly string connectionString;
        public DesignTimeContextFactory()
        {
            var helper = new ConfigurationHelper(CONNECTION_STRING_CONFIG_KEY);
            connectionString = helper.GetConnectionString();
        }
        public SCNConnectDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SCNConnectDBContext> builder = new DbContextOptionsBuilder<SCNConnectDBContext>();
            builder.UseSqlServer(connectionString);
            return new SCNConnectDBContext(builder.Options);
        }
    }
}