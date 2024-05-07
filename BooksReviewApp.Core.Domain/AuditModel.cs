namespace BooksReviewApp.Core.Domain
{
    public class AuditModel
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
