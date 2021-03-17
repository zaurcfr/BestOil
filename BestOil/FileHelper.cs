using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOil
{
    class FileHelper
    {
        public static void JsonSerialize(string filename,double price)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{filename}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, price);
                }
            }
        }
    }
}
