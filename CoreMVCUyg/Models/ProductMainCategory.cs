using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreMVCUyg.Models
{
    public class ProductMainCategory
    {
        public ProductMainCategory()
        {
            this.ProductSubCategorys = new HashSet<ProductSubCategory>();
            this.ProductCategorys = new HashSet<ProductCategory>();
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int ProductMainCategoryId { get; set; }

        [Required(ErrorMessage = "Ana Kategori Adı alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Ana Kategori")]
        public string ProductMainCategoryName { get; set; }

        [Required(ErrorMessage = "Sıra alanı zorunludur.")]
        [Display(Name = "Sıra")]
        public int Order { get; set; }

        public virtual ICollection<ProductSubCategory> ProductSubCategorys { get; set; }
        public virtual ICollection<ProductCategory> ProductCategorys { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
