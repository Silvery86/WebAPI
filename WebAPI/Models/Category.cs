using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Category")]   
    
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CategoryAlias { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100, ErrorMessage = "Category Name cannot be longer than 100 characters")]
        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; } 
    }
}
