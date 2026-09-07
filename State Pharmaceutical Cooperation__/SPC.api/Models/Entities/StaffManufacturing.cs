using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPC.api.Models.Entities
{
    public partial class StaffManufacturing
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }
    }
}
