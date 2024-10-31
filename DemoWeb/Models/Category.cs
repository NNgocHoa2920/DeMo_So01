using System.ComponentModel.DataAnnotations;

namespace DemoWeb.Models
{
    public class Category
    {
        [Key]
        public int Ma { get; set; }
        [Required]
        [MaxLength(255)]
       
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Độ dài  1-100 kí tự")]
        public string Description { get; set; }
    }
}
