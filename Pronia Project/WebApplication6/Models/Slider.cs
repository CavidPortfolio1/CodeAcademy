using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(3,MinimumLength = 1, ErrorMessage="Maks 3 minimum 1")]
        public string Discount { get; set; }
        [Required]
        [StringLength(30 , MinimumLength = 3, ErrorMessage ="Maks 30 minimum 3")]
        public string Name { get; set; }
        [Required]
        [StringLength(120,MinimumLength = 5 , ErrorMessage = "Maks 120 minimum 5")]
        public string Description { get;set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
