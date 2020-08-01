using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class ViewDefinitionCriteria:IModel
    {
        public int Id { get; set; }
        
        public bool IsTemplate { get; set; }
        public string Signature { get; set; }
        
        [JsonIgnore]
        public View View { get; set; }
        public int? ViewId { get; set; }

        [JsonIgnore]
        public List<ViewDefinitionCriteriaParam> ViewDefinitionCriteriaParams { get; set; }
        
        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}