using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine((new { Id = 1, Name = "Jay" }).ToJson());
            Console.Read();
        }
    }
    public static class Exstension
    {
        public static string ToJson<T>(this T t) where T : class
        {
            return t == null ? "[]" : JsonConvert.SerializeObject(t);
        }
    }
}
