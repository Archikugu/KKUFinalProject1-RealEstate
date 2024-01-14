using System.Net.Mail;

namespace E_State.UI.Areas.User.MailHelper
{
    public class ResetPassword
    {
        public static void PasswordSendMail(string link, string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.From = new MailAddress("system@mail.com");
            mail.To.Add(email);
            mail.Subject = "Şifre Güncelleme Talebi";
            mail.Body = "<h2>Şifrenizi yenilemek için linke tıklayınız <h2> <hr>";
            mail.Body += $"<a href='{link}'> Şifre Yenileme Bağlantısı</a>";

            mail.IsBodyHtml = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("engokhangok@gmail.com", "zxtm iqei ogzm llyj");
            smtp.Send(mail);
        }
    }
}
