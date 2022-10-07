using System.ComponentModel.DataAnnotations;

namespace BlazorLoker2022.Resource.Admin.Login
{
    public class AdminUbahPassword
    {
        [Required(ErrorMessage = "Password Lama Tidak Boleh Kosong")]
        public string passwordLama { get; set; }

        [Required(ErrorMessage = "Password Baru Tidak Boleh Kosong")]
        public string passwordBaru { get; set; }
    }
}
