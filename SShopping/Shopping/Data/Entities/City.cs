using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        // estas son Data anotetion
        [Display(Name = "Ciudad")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")] //Required hace que el campo sea obligatorio
        public string Name { get; set; }

        [JsonIgnore]
        public State State { get; set; }   // 1 ciudad tiene 1 Provincia

        public ICollection<User> Users { get; set; }    

    }
}
