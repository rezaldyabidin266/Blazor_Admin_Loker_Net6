using System.ComponentModel.DataAnnotations;

namespace BlazorLoker2022.Resource.Admin.Login
{
    public class AdminLoginClass
    {
        [Required(ErrorMessage = "Username Tidak Boleh Kosong")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password Tidak Boleh Kosong")]
        public string password { get; set; }
        public string ipAddress { get; set; }
        public string browser { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string remarks { get; set; }
    }
}
