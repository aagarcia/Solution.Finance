namespace Solution.Finance.Domain.Commons
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime? Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? Updated { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? Deleted { get; set; }

        public string? DeletedBy { get; set; }
    }
}
