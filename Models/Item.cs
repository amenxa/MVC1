using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcapl1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="this field is required")]
        [MaxLength(55)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Price")]
        public int price { get; set; }
       
        public DateTime DateTime { get; set; } = DateTime.Now;
        [ForeignKey("Category")]
        public int categoryId { get; set; } 
        public Category? category { get; set; }

    }
}
