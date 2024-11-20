using Identity.WebApi.Integration.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Identity.WebApi.Integration
{
    public class IntegrationService : IIntegrationService
    {
        private const string AccountControllerRoute = "account";
        private const string CreateAccountEndpoint = "account/register";
        private const string AccountEndpointWithId = "account/{0}";
        private const string AuthenticationControllerLoginEndpoint = "authentication/login";

        private readonly HttpClient _httpClient;
        private readonly string _login;
        private readonly string _password;

        public IntegrationService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            var baseUrl = configuration["ApiSettings:IdentityApiBaseUrl"] ?? throw new ArgumentException("Identity API base URL is not configured in the appsettings.");
            _login = configuration["ApiSettings:Login"] ?? throw new ArgumentException("Identity API Login is not configured in the appsettings.");
            _password = configuration["ApiSettings:Password"] ?? throw new ArgumentException("Identity API Password is not configured in the appsettings.");

            _httpClient = httpClientFactory.CreateClient("IdentityApi");
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<Guid> CreateUserAsync(CreateUserModel createUser)
        {
            var response = await _httpClient.PostAsJsonAsync(CreateAccountEndpoint, createUser);

            EnsureSuccessResponseAsync(response, "User creation");
            var result = await response.Content.ReadFromJsonAsync<Guid>();

            return result;
        }

        public async Task UpdateUserAsync(UpdateUserModel updateUser)
        {
            await AuthenticateUserAsync();
            var response = await _httpClient.PutAsJsonAsync(AccountControllerRoute, updateUser);

            EnsureSuccessResponseAsync(response, "User update");
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await AuthenticateUserAsync();

            var deleteEndpoint = string.Format(AccountEndpointWithId, userId);
            var response = await _httpClient.DeleteAsync(deleteEndpoint);

            EnsureSuccessResponseAsync(response, "User deletion");
        }

        private static void EnsureSuccessResponseAsync(HttpResponseMessage response, string operationName)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"{operationName} failed: {response.ReasonPhrase}");
            }
        }

        private async Task AuthenticateUserAsync()
        {
            var loginPayload = new { UserName = _login, Password = _password };
            await _httpClient.PostAsJsonAsync(AuthenticationControllerLoginEndpoint, loginPayload);
        }
    }
}
