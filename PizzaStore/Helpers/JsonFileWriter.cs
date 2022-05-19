using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaStore2.Helpers
{
    class JsonFileWriter
    {
        public static void WriteToJson(Dictionary<int, Pizza> pizzas, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(pizzas, Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
