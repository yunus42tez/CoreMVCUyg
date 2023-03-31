using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class ProductSubCategory
    {
        public ProductSubCategory()
        {
            this.ProductCategorys = new HashSet<ProductCategory>();
            this.Products = new HashSet<Product>();

        }
        [Key]
        public int ProductSubCategoryId { get; set; }

        [Required(ErrorMessage = "Alt Kategori Adı alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = " Alt Kategori")]
        public string ProductSubCategoryName { get; set; }

        [Required(ErrorMessage = "Sıra alanı zorunludur.")]
        [Display(Name = "Sıra")]
        public int Order { get; set; }


        [Display(Name = "Ana Kategori")]
        [ForeignKey("UrunAnaKategori")]
        public int? ProductMainCategoryId { get; set; }
        public virtual ProductMainCategory ProductMainCategorys { get; set; }

        public virtual ICollection<ProductCategory> ProductCategorys { get; set; }
        public virtual ICollection<Product> Products { get; set; }

       
    }
}
