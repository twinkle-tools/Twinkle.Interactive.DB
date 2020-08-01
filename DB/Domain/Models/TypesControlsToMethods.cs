using DBService.Domain.Interfaces;

namespace DBService.Domain.Models
{
    public class TypesControlsToMethods:IModel
    {
        public int Id { get; set; }
        
        public int TypeControlId { get; set; }
        public TypeControl TypeControl { get; set; }

        public int MethodId { get; set; }
        public Method Method { get; set; }

    }
}