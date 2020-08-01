using DBService.Domain.Interfaces;

namespace DBService.Domain.Models
{
    public class MethodToTreatmentOptions:IModel
    {
        public int Id { get; set; }
        
        public int MethodId { get; set; }
        public Method Method { get; set; }

        public int TreatmentOptionId { get; set; }
        public TreatmentOption TreatmentOption { get; set; }
    }
}