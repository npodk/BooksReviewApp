namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IGuardService
    {
        Task<bool> UserHasPermissionAsync(Guid userId, string permissionName);
    }
}
