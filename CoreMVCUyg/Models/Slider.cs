using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sıra alanı zorunludur.")]
        [Display(Name = "Sıra")]
        public int Order { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Kısa Açıklama alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Resim alanı zorunludur.")]
        [Display(Name = "Resim")]
        public string ImagePath { get; set; }
    }
}
