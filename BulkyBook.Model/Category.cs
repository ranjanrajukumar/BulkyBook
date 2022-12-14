using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Please enter between 1 t0 100number")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; }= DateTime.Now;
    }
}
