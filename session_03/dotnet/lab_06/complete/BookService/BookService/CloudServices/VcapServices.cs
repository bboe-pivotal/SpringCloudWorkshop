using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.CloudServices
{
    public class VcapServices
    {
        private static readonly Logger Nlog = LogManager.GetCurrentClassLogger();
        private static VcapServices instance;
        private string rawEnv = null;
        private JObject parsedEnv = null;
        private Dictionary<string, JToken> serviceDictionary = null;
        
        public static VcapServices Instance()
        {
            if (instance == null)
            {
                instance = new VcapServices();
                Nlog.Trace("Checking for VCAP_SERVICES");
                instance.rawEnv = Environment.GetEnvironmentVariable("VCAP_SERVICES");
                if (instance.rawEnv != null)
                {
                    Nlog.Trace("Parsing VCAP_SERVICES");
                    instance.parsedEnv = JObject.Parse(instance.rawEnv);

                    Nlog.Trace("Getting services from parsed VCAP_SERVICES");
                    instance.serviceDictionary =
                        instance.parsedEnv.Children().Children().Children().ToDictionary(val => val["name"].ToString(), val => val);
                }
            }
            return instance;
        }

        public bool IsCF
        {
            get
            {
                return rawEnv != null;
            }
        }

        public JToken GetService(string name)
        {
            return serviceDictionary[name];
        }
    }
}