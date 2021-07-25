using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinstarApp.Data
{
    public class DataObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
