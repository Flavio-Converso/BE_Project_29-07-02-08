using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Project_29_07_02_08.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRole { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        // Riferimenti EF
        public List<User> Users { get; set; } = new List<User>();
    }
}
