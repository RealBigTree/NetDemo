using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Json.NewtonsoftJson {
    public class ExNewtonsoftJson {
        public static Dictionary<string, JToken> GetJsonKeyValuePair(string jsonStr) {
            var dic = new Dictionary<string, JToken>();
            var o = JObject.Parse(jsonStr);
            foreach (JToken child in o.Children()) {
                var pp = child as JProperty;
                dic.Add(pp.Name, pp.Value);
            }
            return dic;
        }
    }
}
