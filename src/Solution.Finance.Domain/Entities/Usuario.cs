using Solution.Finance.Domain.Commons;

namespace Solution.Finance.Domain.Entities
{
    public class Usuario : BaseAuditableEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }
    }
}
