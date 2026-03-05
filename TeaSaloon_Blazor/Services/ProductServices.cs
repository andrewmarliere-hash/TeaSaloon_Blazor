using TeaSaloon_API.Models;
using System.Net.Http.Json;


namespace TeaSaloon_Blazor.Services
{

    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("API");
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Product>>("products") ?? new List<Product>();
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"products/{id}");
        }

        public async Task<bool> AddAsync(Product product)
        {
            var response = await _http.PostAsJsonAsync("products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var response = await _http.PutAsJsonAsync($"products/{product.ProductID}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}

