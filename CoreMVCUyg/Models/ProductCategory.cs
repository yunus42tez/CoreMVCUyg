using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int ProductCategoryId { get; set; }
        [Required(ErrorMessage = "Kategori Adı alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Kategori Adı")]
        public string ProductCategoryName { get; set; }
        [Required(ErrorMessage = "Sıra alanı zorunludur.")]
        [Display(Name = "Sıra")]
        public int Order { get; set; }


        [Display(Name = "Ana Kategori")]
        [ForeignKey("UrunAnaKategori")]
        public int? ProductMainCategoryId { get; set; }
        public virtual ProductMainCategory ProductMainCategorys { get; set; }

        [Display(Name = "Alt Kategori")]
        [ForeignKey("UrunAltKategori")]
        public int? ProductSubCategoryId { get; set; }
        public virtual ProductSubCategory ProductSubCategorys { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
