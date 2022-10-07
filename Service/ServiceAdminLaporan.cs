using BlazorAdminLoker2022.Resource.Laporan;
using Newtonsoft.Json;

namespace BlazorAdminLoker2022.Service
{
    public class ServiceAdminLaporan
    {
        private readonly HttpClient _httpClient;
        private const string Controller = "Laporan/";

        public ServiceAdminLaporan(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AdminCalonPelamar>> getCalonPelamar()
        {
            var respond = await _httpClient.GetAsync(Controller + $"calon-pelamar");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminCalonPelamar>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
        public async Task<List<AdminAllHistoryJawaban>> getAllHistoryJawaban()
        {
            var respond = await _httpClient.GetAsync(Controller + $"all-history-jawaban");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminAllHistoryJawaban>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
        public async Task<List<AdminHistoryJawabanByLokerClass>> getHistoryJawabanByLoker(int IdLoker)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("lokerId", IdLoker.ToString());
            var respond = await _httpClient.GetAsync(Controller + $"history-jawaban-by-loker");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminHistoryJawabanByLokerClass>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
        public async Task<List<AdminHistoryJawabanByPelamarClass>> getHistoryJawabanByPelamar(int pelamarId)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("pelamarId", pelamarId.ToString());
            var respond = await _httpClient.GetAsync(Controller + $"history-jawaban-by-pelamar");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<List<AdminHistoryJawabanByPelamarClass>>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
        public async Task<AdminHistoryDetailJawaban> getHistoryDetailJawaban(int headerJawabanId)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("headerJawabanId", headerJawabanId.ToString());
            var respond = await _httpClient.GetAsync(Controller + $"history-detail-jawaban");

            return respond.IsSuccessStatusCode
              ? JsonConvert.DeserializeObject<AdminHistoryDetailJawaban>(respond.Content.ReadAsStringAsync().Result)
              : throw new Exception(await respond.Content.ReadAsStringAsync());
        }
    }
}
