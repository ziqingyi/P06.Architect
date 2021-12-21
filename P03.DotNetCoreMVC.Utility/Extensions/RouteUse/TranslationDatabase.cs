using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.Extensions.RouteUse
{
    //data source
    public class TranslationDatabase
    {

        /// https://localhost:5177/en/home/index
        /// https://localhost:5177/fr/home1/index1
        /// https://localhost:5177/ch/home2/index2
        private static Dictionary<string, Dictionary<string, string>> translations 
            = new Dictionary<string, Dictionary<string, string>>()
            {
                {"en",  new Dictionary<string, string>{  {"home","Home"}, {"index","Index"}   }       },
                {"fr",  new Dictionary<string, string>{  {"home1","Home"}, {"index1","Index"} }       },
                {"ch",  new Dictionary<string, string>{  {"home2","Home"}, {"index2","Index"} }       }
            };
        


        public async Task<string> Resolve(string language, string value)
        {
            var normalizeLang = language.ToLowerInvariant();
            var normalizedValue = value.ToLowerInvariant();

            if(translations.ContainsKey(normalizeLang) && translations[normalizeLang].ContainsKey(normalizedValue))
            {
                return translations[normalizeLang][normalizedValue];
            }
            return null;
        }






    }
}
