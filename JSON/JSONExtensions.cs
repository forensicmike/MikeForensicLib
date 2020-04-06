using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib
{
    static public class JSONExtensions
    {
        static public dynamic ToEzJson(this JToken input)
        {
            var ret = new ExpandoObject();
            var nResultDict = (IDictionary<string, object>)ret;


            //foreach (var item in columnNames)
            //{
            //    nResultDict.Add(item.Value, reader[item.Key]);
            //}
            //ret.Add(nResult);

            return ret;
        }
    }
}
