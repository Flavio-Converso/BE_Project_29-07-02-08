using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Project_29_07_02_08.Models
{
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdIngredient { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }


        // Riferimenti EF
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
