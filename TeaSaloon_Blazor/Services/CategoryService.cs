using System.Net.Http.Json;
using TeaSaloon_API.Models;

namespace TeaSaloon_Blazor.Services
{
    public class CategoryService
    {

        private readonly HttpClient _http;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Category>>("categories") ?? new List<Category>();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Category>($"categories/{id}");
        }

        public async Task<bool> AddAsync(Category category)
        {
            var response = await _http.PostAsJsonAsync("categories", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            var response = await _http.PutAsJsonAsync($"categories/{category.CategoryID}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"categories/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
