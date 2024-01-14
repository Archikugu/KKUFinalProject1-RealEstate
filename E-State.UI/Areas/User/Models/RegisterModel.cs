using System.ComponentModel.DataAnnotations;

namespace E_State.UI.Areas.User.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "E-Mail Alanı Boş Geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi Onayla Alanı Boş Geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        public string FullName { get; set; }
    }
}
