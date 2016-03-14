using MySql.Data.Entity;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(BookService.CloudServices.EFConfigurer), "Configure")]
namespace BookService.CloudServices
{
    public class EFConfigurer
    {
        public static void Configure()
        {
            VcapServices vcapServices = VcapServices.Instance();
            if(vcapServices.IsCF)
            {
                JToken service = vcapServices.GetService("BookServiceContext");

                IEnumerator<JToken> tags = service["tags"].Values().GetEnumerator();
                while(tags.MoveNext())
                {
                    if("mysql".Equals(tags.Current.ToString()))
                    {
                        DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
                    }
                }
            }
        }
    }
}