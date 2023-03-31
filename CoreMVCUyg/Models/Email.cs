using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Sunucu alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Sunucu")]
        public string Host { get; set; }
        [Required(ErrorMessage = "Port alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Port")]
        public string Port { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [StringLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Tarih")]
        public System.DateTime GetDateTime { get; set; }
    }
}
