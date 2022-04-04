using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        // estas son Data anotetion
        [Display(Name = "Provincias")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")] //Required hace que el campo sea obligatorio
        public string Name { get; set; }

        [JsonIgnore]
        public Country Country { get; set; } // 1 provincia solo tiene 1 PAIS

        public ICollection<City> Cities { get; set; } // 1 provincia tiene * ciudades

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
