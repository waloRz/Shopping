using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{ 
    public class CityViewModel
    {
        public int Id { get; set; }

        // estas son Data anotetion
        [Display(Name = "Ciudad")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")] //Required hace que el campo sea obligatorio
        public string Name { get; set; }

        public int StateId { get; set; } // me devulve el id de la Provincia a la cual pertenece la ciudad

    }
}
