using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class Method:IModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public bool IsActive { get; set; }
        public string Info { get; set; }
        public bool Deprecated { get; set; }
        public bool CommonMethod { get; set; }
        
        [JsonIgnore]
        public List<MethodParam> MethodParams { get; set; }
        [JsonIgnore]
        public List<MethodToTreatmentOptions> MethodTreatmentOptions { get; set; }
        [JsonIgnore]
        public List<TypesControlsToMethods> TypeControlMethods { get; set; }
        [JsonIgnore]
        public List<ControlsToMethods> ControlMethods { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        
    }
}