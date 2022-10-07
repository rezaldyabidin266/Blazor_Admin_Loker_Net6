namespace BlazorAdminLoker2022.Resource.Loker
{
    public class AdminIdLoker
    {
        public int idLoker { get; set; }
        public string judul { get; set; }
        public string keterangan { get; set; }
        public bool isOpen { get; set; }
        public List<KriteriaDtos> kriteriaDtos { get; set; }
    }
}
