using Identity.WebApi.Integration.Models;

namespace Identity.WebApi.Integration
{
    public interface IIntegrationService
    {
        Task<Guid> CreateUserAsync(CreateUserModel createUser);

        Task DeleteUserAsync(Guid userId);

        Task UpdateUserAsync(UpdateUserModel updateUser);
    }
}
