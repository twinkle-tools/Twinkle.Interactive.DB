using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class TypeControl:IModel
    {
        public int Id { get; set; }
        
        public string Alias { get; set; }

        [JsonIgnore]
        public List<TypesControlsToMethods> ControlMethods { get; set; }
        [JsonIgnore]
        public List<Control> Controls { get; set; }

        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}