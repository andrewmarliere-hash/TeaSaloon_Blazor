using System.Net.Http.Json;
using TeaSaloon_API.Models;

namespace TeaSaloon_Blazor.Services
{
    public class IngredientService
    {
        private readonly HttpClient _http;

        public IngredientService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Ingredient>>("ingredients") ?? new List<Ingredient>();
        }

        public async Task<Ingredient?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Ingredient>($"ingredients/{id}");
        }

        public async Task<bool> AddAsync(Ingredient ingredient)
        {
            var response = await _http.PostAsJsonAsync("ingredients", ingredient);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Ingredient ingredient)
        {
            var response = await _http.PutAsJsonAsync($"ingredients/{ingredient.IngredientID}", ingredient);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"ingredients/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}


