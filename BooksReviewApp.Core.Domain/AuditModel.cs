namespace BooksReviewApp.Core.Domain
{
    public class AuditModel
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public string LastModifiedByName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
