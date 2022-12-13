using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "CoverType")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    } 
}
