using System.Collections.Generic;
using DBService.Domain.Interfaces;
using Newtonsoft.Json;

namespace DBService.Domain.Models
{
    public class Project:IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string DbName { get; set; }
        public string PathToProject { get; set; }
        public string PathToExportViews { get; set; }
        public string NameTestDll { get; set; }
        
        [JsonIgnore]
        public List<View> Views { get; set; }
        [JsonIgnore]
        public List<TypeControl> TypeControls { get; set; }
        [JsonIgnore]
        public List<TreatmentOption> TreatmentOptions { get; set; }
        [JsonIgnore]
        public List<Method> Methods { get; set; }
    }
}