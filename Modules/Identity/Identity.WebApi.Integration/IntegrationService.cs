using Identity.WebApi.Integration.Models;
using Microsoft.Extensions.Options;
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
        private readonly ApiSettings _apiSettings;

        public IntegrationService(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> options)
        {
            _apiSettings = options.Value ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(_apiSettings.IdentityApiBaseUrl))
                throw new ArgumentException("Identity API base URL is not configured.");
            if (string.IsNullOrEmpty(_apiSettings.Login))
                throw new ArgumentException("Identity API login is not configured.");
            if (string.IsNullOrEmpty(_apiSettings.Password))
                throw new ArgumentException("Identity API password is not configured.");

            _httpClient = httpClientFactory.CreateClient("IdentityApi");
            _httpClient.BaseAddress = new Uri(_apiSettings.IdentityApiBaseUrl);
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
            var loginPayload = new { UserName = _apiSettings.Login, _apiSettings.Password };
            await _httpClient.PostAsJsonAsync(AuthenticationControllerLoginEndpoint, loginPayload);
        }
    }
}
