using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class Product
    {
        [Key]
        public int UrunID { get; set; }
        [Required(ErrorMessage = "Ürün Adı alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Ürün")]
        public string UrunAd { get; set; }
        [Required(ErrorMessage = "Resim alanı zorunludur.")]
        [Display(Name = "Resim 1")]
        public string ImagePath { get; set; }
        [Display(Name = "Resim 2")]
        public string ImagePath2 { get; set; }
        [Display(Name = "Resim 3")]
        public string ImagePath3 { get; set; }
        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Vitrin")]
        public bool Vitrin { get; set; }

        [Display(Name = "Ana Kategori")]
        [ForeignKey("UrunAnaKategori")]
        public int? ProductMainCategoryId { get; set; }
        public virtual ProductMainCategory ProductMainCategorys { get; set; }

        [Display(Name = "Alt Kategori")]
        [ForeignKey("UrunAltKategori")]
        public int? ProductSubCategoryId { get; set; }
        public virtual ProductSubCategory ProductSubCategorys { get; set; }

        [Display(Name = "Kategori")]
        [ForeignKey("UrunKategori")]
        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategorys { get; set; }
    }
}
