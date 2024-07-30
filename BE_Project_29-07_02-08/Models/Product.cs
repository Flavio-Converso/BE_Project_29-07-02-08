using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Project_29_07_02_08.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }



        public byte[]? Image { get; set; }

        [Required]
        [Range(0, 60)]
        public int DeliveryTimeMin { get; set; }


        // Riferimenti EF
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}
