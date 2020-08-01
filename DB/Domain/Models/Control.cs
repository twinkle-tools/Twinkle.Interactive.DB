using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class Control:IModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public bool IsActive { get; set; }
        public string XPath { get; set; }
        public string Css { get; set; }
        
        [JsonIgnore]
        public View View { get; set; }
        public int ViewId { get; set; }
        
        [JsonIgnore]
        public List<ControlsToMethods> ControlsMethods { get; set; }
        
        [JsonIgnore]
        public TypeControl TypeControl { get; set; }
        public int TypeControlId { get; set; }
    }
}