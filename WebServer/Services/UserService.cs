using WebServer.Models;

namespace WebServer.Services
{
    public interface IUserService
    {
        Task<UserResponse?> GetUsersAsync(int pageNumber);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        
        public async Task<UserResponse?> GetUsersAsync(int pageNumber)
        {
            var url = "https://reqres.in/api/users?page=" + pageNumber;

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserResponse>();
            }

            return new UserResponse();
        }
    }
}