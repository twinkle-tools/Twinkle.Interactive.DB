using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class TreatmentOption:IModel
    {
        public int Id { get; set; }
        
        public string Type { get; set; }
        public int Signature { get; set; }

        [JsonIgnore]
        public List<MethodToTreatmentOptions> MethodTreatmentOptions { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}