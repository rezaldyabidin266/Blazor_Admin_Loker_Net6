using BlazorLoker2022.Resource.Admin.Login;
using System.Net.Http.Json;

namespace BlazorAdminLoker2022.Service
{
    public class ServiceAdminLogin
    {
        private readonly HttpClient _httpClient;
        private const string Controller = "Login/";

        public ServiceAdminLogin(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdminKalimatMotivasi>> adminMotivasi()
        {
            return await _httpClient.GetFromJsonAsync<List<AdminKalimatMotivasi>>(Controller + "list-kalimat-motivasi");
        }

        public async Task<byte[]> adminGambarMotivasi()
        {
            return await _httpClient.GetByteArrayAsync(Controller + "gambar-motivasi");
        }

        public async Task<string> loginAdmin(AdminLoginClass adminLogin)
        {
            var respond = await _httpClient.PostAsJsonAsync(Controller, adminLogin);
            if (respond.IsSuccessStatusCode)
            {
                return await respond.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(await respond.Content.ReadAsStringAsync());
            }
        }
        public async Task<string> ubahPassword(AdminUbahPassword ubahPassword)
        {
            var respond = await _httpClient.PutAsJsonAsync(Controller + $"ubah-password", ubahPassword);
            return respond.IsSuccessStatusCode
              ? await respond.Content.ReadAsStringAsync()
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
    }
}
