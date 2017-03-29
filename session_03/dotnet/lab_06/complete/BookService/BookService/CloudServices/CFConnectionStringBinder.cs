using BookService.Models;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BookService.CloudServices
{
    public class CFConnectionStringBinder
    {
        private static readonly Logger Nlog = LogManager.GetCurrentClassLogger();

        private static Dictionary<string, string> conStringCache = new Dictionary<string, string>();

        public static string Bind(string connectionStringName)
        {
            Nlog.Trace(String.Format("Checking for {0} in cached strings", connectionStringName));
            string conStr = null;
            if (conStringCache.ContainsKey(connectionStringName)) conStr = conStringCache[connectionStringName];
            else
            {
                conStr = LookupString(connectionStringName);
                conStringCache[connectionStringName] = conStr;
            }

            return conStr;
        }

        private static string LookupString(string connectionStringName)
        {
            if( ConfigurationManager.ConnectionStrings[connectionStringName] == null)
            {
                Nlog.Error("No connection string found matching given connection string name, returning null...");
                return null;
            }

            VcapServices vcap = VcapServices.Instance();

            if (!vcap.IsCF)
            {
                Nlog.Info("VCAP_SERVICES not set - returning connection string from app config...");
                return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }

            Nlog.Trace(String.Format("Checking for {0} in VCAP_SERVICES", connectionStringName));
            JToken service = vcap.GetService(connectionStringName);

            if (service != null)
            {
                Nlog.Trace(String.Format("Found service named {0} in VCAP_SERVICES.  Reconfiguring for bound services.", connectionStringName));
                JToken creds = service["credentials"];
                string conString = "";
                if(creds["connectionString"] != null)
                {
                    conString = creds["connectionString"].ToString();
                }
                else
                {
                    conString = String.Format("server={0};port={1};database={2};uid={3};password={4};",
                        creds["hostname"],
                        creds["port"],
                        creds["name"],
                        creds["username"],
                        creds["password"]);
                }
                Nlog.Debug(conString);
                return conString;
            }
            else
            {
                Nlog.Info("Couldn't find bound service - returning connection string from app config...");
                return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }
        }
    }
}