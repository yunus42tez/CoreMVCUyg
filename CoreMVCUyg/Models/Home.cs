using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Header { get; set; }

        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Resim alanı zorunludur.")]
        [Display(Name = "Resim")]
        public string ImagePath { get; set; }
    }
}
