using System.ComponentModel.DataAnnotations;

namespace E_State.UI.Areas.User.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Boş Geçilemez")]
        //public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email tipinde değil")]
        public string Email { get; set; }
    }
}
