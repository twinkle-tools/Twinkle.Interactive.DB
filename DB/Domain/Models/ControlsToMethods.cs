using DBService.Domain.Interfaces;

namespace DBService.Domain.Models
{
    public class ControlsToMethods:IModel
    {
        public int Id { get; set; }
        
        public int ControlId { get; set; }
        public Control Control { get; set; }

        public int MethodId { get; set; }
        public Method Method { get; set; }
    }
}