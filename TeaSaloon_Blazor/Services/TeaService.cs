using TeaSaloon_API.Models;

namespace TeaSaloon_Blazor.Services
{
    public class TeaService
    {

        private readonly HttpClient _http;

        public TeaService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Tea>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Tea>>("teas") ?? new List<Tea>();
        }

        public async Task<Tea?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Tea>($"teas/{id}");
        }

        public async Task<bool> AddAsync(Tea tea)
        {
            var response = await _http.PostAsJsonAsync("teas", tea);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Tea tea)
        {
            var response = await _http.PutAsJsonAsync($"teas/{tea.ProductID}", tea);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"teas/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
