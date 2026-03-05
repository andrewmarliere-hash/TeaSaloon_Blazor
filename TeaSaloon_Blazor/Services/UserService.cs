using TeaSaloon_API.Models;

namespace TeaSaloon_Blazor.Services
{
    public class UserService
    {

        private readonly HttpClient _http;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<User>>("users") ?? new List<User>();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<User>($"users/{id}");
        }

        public async Task<bool> AddAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("users", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var response = await _http.PutAsJsonAsync($"users/{user.UserID}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
