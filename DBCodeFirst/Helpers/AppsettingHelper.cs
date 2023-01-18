using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCodeFirst.Helpers
{
    internal static class AppsettingHelper
    {
        public static string GetConnectionString(string stringName)
        {
            var builder = new ConfigurationBuilder();
            // set the path to the current directory
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // get configuration from appsettings.json file
            builder.AddJsonFile("appsettings.json");
            // create configuration
            var config = builder.Build();
            // get connection string
            return config.GetConnectionString(stringName) ?? throw new NullReferenceException($"There is no such connection string: \"{stringName}\"");
        }
    }
}
