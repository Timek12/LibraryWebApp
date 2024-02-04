using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 1000)]
        public int DisplayOrder { get; set; }
    }
}
