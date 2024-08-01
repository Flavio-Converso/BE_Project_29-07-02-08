using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Project_29_07_02_08.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }

        [Required]
        [StringLength(200)]
        public required string Address { get; set; }

        [StringLength(500)]
        public string? AdditionalNotes { get; set; }

        public bool IsProcessed { get; set; } = false; //evaso

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // Riferimenti EF
        [Required]
        public int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        public List<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();


    }
}
