using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models
{
    public partial class AdminDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
