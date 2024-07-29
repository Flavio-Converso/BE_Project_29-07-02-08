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
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        [Range(0, 1000)]
        public int DeliveryTime { get; set; }


        // Riferimenti EF
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}
