using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class MethodParam:IModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }
        public string ParamLabel { get; set; }

        [JsonIgnore]
        public List<TableColumn> TableColumns { get; set; }
        
        [JsonIgnore]
        public Method Method { get; set; }
        public int MethodId { get; set; }
        
    }
}