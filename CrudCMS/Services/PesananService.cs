using CrudLibrary;
using System.Net.Http.Json;

namespace CrudCMS.Services
{
    public class PesananService : IPesananService
    {
        private readonly HttpClient _http;

        public PesananService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PesananDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<PesananDTO>>>("api/pesanan/List");
            if (result!.IsSuccess)
                return result.Value!;
            else
                throw new Exception(result.Message);
        }

        public async Task<PesananDTO> Search(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<PesananDTO>>($"api/pesanan/Search/{id}");
            if (result!.IsSuccess)
                return result.Value!;
            else
                throw new Exception(result.Message);
        }

        public async Task<int> Save(PesananDTO pesanan)
        {
            var result = await _http.PostAsJsonAsync("api/pesanan/Save",pesanan);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.IsSuccess)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<int> Edit(PesananDTO pesanan)
        {
            var result = await _http.PutAsJsonAsync($"api/pesanan/Edit/{pesanan.IdPesanan}", pesanan);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.IsSuccess)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/pesanan/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.IsSuccess)
                return response.IsSuccess;
            else
                throw new Exception(response.Message);
        }

    }
}
