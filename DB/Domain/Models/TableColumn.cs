using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class TableColumn:IModel
    {
        public int Id { get; set; }
        
        public string Alias { get; set; }
        
        [JsonIgnore]
        public MethodParam MethodParam { get; set; }
        public int MethodParamId { get; set; }
    }
}