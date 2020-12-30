using MusicController.Shared.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicController.Shared
{
    public static class Utility
    {
        public static string Env()
        {
            var environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment.EnvironmentName);
            return environment;
        }
        
        public static string EnvironmentFile()
        {
            string filename = EnvironmentType.Production;
            switch (Env())
            {
                case "Development":
                    filename = "appsettings.Development.json";
                    break;
                case "Staging":
                    filename = "appsettings.Staging.json";
                    break;
                case "Production":
                    filename = "appsettings.json";
                    break;
            }
            return filename;
        }
    }
}
