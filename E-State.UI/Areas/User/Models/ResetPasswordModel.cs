using System.ComponentModel.DataAnnotations;

namespace E_State.UI.Areas.User.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "E-Mail Alanı Boş Geçilemez")]
        [EmailAddress(ErrorMessage ="E-Posta Formatında Değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "E-Mail Alanı Boş Geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre Formatına Uygun Değil")]
        public string NewPassword { get; set; }
    }
}
