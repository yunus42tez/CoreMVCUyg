using System.ComponentModel.DataAnnotations;

namespace CoreMVCUyg.Models
{
    public class WebsiteInfo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Display(Name = "Ünvan")]
        public string Unvan { get; set; }

        [StringLength(250)]
        [Display(Name = "Slogan")]
        public string Slogan { get; set; }

        [StringLength(250)]
        [Display(Name = "Çalışma Saatleri")]
        public string CalismaSaat { get; set; }

        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        [StringLength(300)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [StringLength(300)]
        [Display(Name = "Adres 2")]
        public string Adres2 { get; set; }
        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [StringLength(250)]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }
        [StringLength(250)]
        [Display(Name = "Telefon 2")]
        public string Telefon2 { get; set; }
        [StringLength(250)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "E-Posta alanı zorunludur.")]
        [StringLength(250)]
        [Display(Name = "E-Posta")]
        public string EPosta { get; set; }

        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
        [Display(Name = "LinkedIn")]
        public string Linkedin { get; set; }
        [Display(Name = "Youtube")]
        public string Youtube { get; set; }
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }
        [Display(Name = "GooglePlus")]
        public string GooglePlus { get; set; }
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [Required(ErrorMessage = "Google Map Link alanı zorunludur.")]
        [Display(Name = "Google Map Link")]
        public string GoogleMapLink { get; set; }
        [Required(ErrorMessage = "Hakkımızda Kısa Açıklama alanı zorunludur.")]
        [Display(Name = "Hakkımızda Kısa Açıklama (Footer)")]
        public string HakkimizdaFooterAciklama { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Yazar(Author) alanı zorunludur.")]
        [Display(Name = "Yazar(Author)")]
        public string Author { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Tasarımcı(Designer) alanı zorunludur.")]
        [Display(Name = "Tasarımcı(Designer)")]
        public string Designer { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "İçerik Dili(Content Language) alanı zorunludur.")]
        [Display(Name = "İçerik Dili(Content Language)")]
        public string ContentLanguage { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Robotlar(Robots) alanı zorunludur.")]
        [Display(Name = "Robotlar(Robots)")]
        public string Robots { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Karakter Seti(Charset) alanı zorunludur.")]
        [Display(Name = "Karakter Seti(Charset)")]
        public string Charset { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Bölge(Distribution) alanı zorunludur.")]
        [Display(Name = "Bölge(Distribution)")]
        public string Distribution { get; set; }
        [Required(ErrorMessage = "Telif Hakkı(Copyright) alanı zorunludur.")]
        [StringLength(250)]
        [Display(Name = "Telif Hakkı(Copyright)")]
        public string Copyright { get; set; }
        [StringLength(500)]
        [Display(Name = "Özet")]
        public string Abstract { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Hedef Kitle(Raiting) alanı zorunludur.")]
        [Display(Name = "Hedef Kitle(Raiting)")]
        public string Raiting { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Sınıflandırma(Classification alanı zorunludur.")]
        [Display(Name = "Sınıflandırma(Classification)")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Meta Başlık alanı zorunludur.")]
        [Display(Name = "Meta Başlık")]
        public string MetaTitle { get; set; }
        [Required(ErrorMessage = "Meta Açıklama alanı zorunludur.")]
        [Display(Name = "Meta Açıklama")]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = "Meta Anahtar Kelimeler alanı zorunludur.")]
        [Display(Name = "Meta Anahtar Kelimeler")]
        public string MetaKeywords { get; set; }
    }
}
