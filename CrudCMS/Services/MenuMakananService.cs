using CrudLibrary;
using System.Net.Http.Json;

namespace CrudCMS.Services
{
    public class MenuMakananService : IMenuMakananService
    {
        private readonly HttpClient _http;

        public MenuMakananService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MenuMakananDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<MenuMakananDTO>>>("api/menumakanan/List");
            if (result!.IsSuccess)
                return result.Value!;
            else
                throw new Exception(result.Message);
        }
    }
}
