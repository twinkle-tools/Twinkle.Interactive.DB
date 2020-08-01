using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class ViewDefinitionCriteriaParam:IModel
    {
        public int Id { get; set; }
        
        public string Alias { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        public ViewDefinitionCriteria ViewDefinitionCriteria { get; set; }
        public int ViewDefinitionCriteriaId { get; set; }
    }
}