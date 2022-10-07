using BlazorAdminLoker2022.Resource.Loker;
using Newtonsoft.Json;

namespace BlazorAdminLoker2022.Service
{
    public class ServiceAdminLoker
    {
        private readonly HttpClient _httpClient;
        private const string Controller = "Loker/";

        public ServiceAdminLoker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdminAllLoker>> GetAllLoker()
        {
            var respond = await _httpClient.GetAsync(Controller + $"all-loker");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminAllLoker>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }

        public async Task<byte[]> GetGambarIlustrasi(int lokerId)
        {
            var respond = await _httpClient.GetAsync(Controller + $"download-image-ilustrasi?lokerId={lokerId}");
            return await respond.Content.ReadAsByteArrayAsync();
        }
        
        public async Task<List<byte[]>> GetGambarIlustrasiList(int lokerId)
        {
            var respond = await _httpClient.GetAsync(Controller + $"download-image-ilustrasi?lokerId={lokerId}");
            var listGambar = new List<byte[]>();
            listGambar.Add(await respond.Content.ReadAsByteArrayAsync());

            return listGambar;
        }
        public async Task<byte[]> GetGambarBackground(int lokerId)
        {
            var respond = await _httpClient.GetAsync(Controller + $"download-image-background?lokerId={lokerId}");

            return respond.IsSuccessStatusCode
              ? await respond.Content.ReadAsByteArrayAsync()
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }

        public string urlUploadIlustrasi()
        {
            return _httpClient.BaseAddress.AbsoluteUri + Controller + "upload-image-ilustrasi";
        }
        public string urlUploadBackground()
        {
            return _httpClient.BaseAddress.AbsoluteUri + Controller + "upload-image-background";
        }

        public async Task<AdminIdLoker> GetIdLoker(int Id)
        {
            var respond = await _httpClient.GetAsync(Controller + $"loker?lokerId={Id}");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<AdminIdLoker>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
        
        public async Task<string> PutLoker(AdminUpdateLoker putLoker)
        {
            var json = JsonConvert.SerializeObject(putLoker);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var respond = await _httpClient.PutAsync(Controller + $"update-loker", content);

            return respond.IsSuccessStatusCode
              ? await respond.Content.ReadAsStringAsync()
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }        
        public async Task<List<AdminQuestionClass>> getQuestion(int idLoker)
        {
            var respond = await _httpClient.GetAsync(Controller + $"question?lokerId={idLoker}");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminQuestionClass>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
    }
}
