using CoreMVCUyg.Data;
using CoreMVCUyg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Mail;

namespace CoreMVCUyg.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MesajGonder(Message message)
        {
            var mail = _context.Email.FirstOrDefault();

            MailMessage email = new MailMessage();
            string Host = mail.Host;
            string smtpUserName = mail.UserName;
            string smtpPassword = mail.Password;
            int smtpPort = Convert.ToInt32(mail.Port);
            email.From = new MailAddress(mail.UserName);
            email.IsBodyHtml = true;
            email.Subject = "CoreMvcUyg - Web Posta";

            email.Body = "<html><body topmargin='0'>";
            email.Body += "<b>Ad-Soyad      : </b>" + message.Name + "<br/>";
            email.Body += "<b>E-posta       : </b>" + message.Email + "<br/><br/>";
            email.Body += "<b>Telefon       : </b>" + message.Phone + "<br/><br/>";
            email.Body += "<b>Konu          : </b>" + message.Subject + "<br/>";
            email.Body += "<b>Mesaj         : </b>" + message.Messages + "<br/><br/>";
            email.Body += "<b>Tarih         : </b>" + Helper.StringManager.TarihYaz(DateTime.Now);
            email.Body += "</body></html>";

            email.To.Add(new MailAddress(mail.UserName));
            email.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient(Host, smtpPort);
            smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
            smtp.EnableSsl = true;
            smtp.Send(email);

            message.GetDateTime = DateTime.Now;
            _context.Message.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index", "Contact");
            //Kullanıcı Adı:yunus42tez@gmail.com
            //Sunucu:smtp.gmail.com
            //Port:587
            //Şifre:wnelbmnbcyekddde şeklinde admin panelde mail ayarları ekle modülünde kaydedilmelidir.
            //Şifre "Google Hesabı-Güvenlik-Uygulama Şifreleri" kısmından alınmalıdır.
        }
    }
}