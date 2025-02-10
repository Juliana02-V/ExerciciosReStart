using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoPOO.App.Extensions
{
    internal static class JsonExtensions
    {
        public static string ToJson (this object obj) 
            {
            return System.Data.JsonSerializer.Serialize(obj);
            }
    }
}
