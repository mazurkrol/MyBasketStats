using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MyBasketStats.ClientApp.Helpers
{
    public class JsonSerializerOptionsWrapper
    {
        public JsonSerializerOptions Options { get; }

        public JsonSerializerOptionsWrapper()
        {
            Options = new JsonSerializerOptions(
                JsonSerializerDefaults.Web);
        }
    }
}
