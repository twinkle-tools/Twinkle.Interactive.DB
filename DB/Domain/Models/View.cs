using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class View:IModel
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string Alias { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public string XPath { get; set; }
        public string Css { get; set; }
        
        [JsonIgnore]
        public List<ViewDefinitionCriteria> ViewDefinitionCriteria { get; set; }
        [JsonIgnore]
        public List<Control> Controls { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        
    }
}