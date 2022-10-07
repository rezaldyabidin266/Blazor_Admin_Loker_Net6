namespace BlazorAdminLoker2022.Resource.Laporan
{
    public class AdminHistoryJawabanByPelamarClass
    {
        public int headerJawabanId { get; set; }
        public int lowonganId { get; set; }
        public string judulLowongan { get; set; }
        public DateTime tglApply { get; set; }
        public string statusLamaran { get; set; }
        public int calonPelamarId { get; set; }
        public object hasilInterview { get; set; }
        public string namaPelamar { get; set; }
        public string noTlp { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdate { get; set; }
        public string userCreated { get; set; }
        public string userUpdate { get; set; }
    }
}
