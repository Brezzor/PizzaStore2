using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaStore2.Helpers
{
    class JsonFileReader
    {
        public static Dictionary<int, Pizza> ReadJson(string JsonFileName)
        {
            string JsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Pizza>>(JsonString);
        }
    }
}
