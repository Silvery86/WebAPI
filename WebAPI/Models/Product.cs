using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductAlias { get; set; }
        [Required]

        public string SKU { get; set; }
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters")]

        public string ProductDescription { get; set; }

        
        public string ProductPrice { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]

        public string ProductImage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
