using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad-Soyad alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Ad-Soyad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [StringLength(300)]
        [Display(Name = "Mesaj")]
        public string Messages { get; set; }
        [Display(Name = "Tarih")]
        public System.DateTime GetDateTime { get; set; }
    }
}
