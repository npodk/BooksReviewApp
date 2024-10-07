namespace BooksReviewApp.Core.Domain.Interfaces
{
    public interface IAuditable
    {
        Guid Id { get; set; }
        Guid? CreatedBy { get; set; }
        string CreatedByName { get; set; }
        Guid? LastModifiedBy { get; set; }
        string LastModifiedByName { get; set; }
        bool IsDeleted { get; set; }
    }
}
