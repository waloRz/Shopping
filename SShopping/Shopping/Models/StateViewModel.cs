using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }

        // estas son Data anotetion
        [Display(Name = "Departamento/Estado")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")] //Required hace que el campo sea obligatorio
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
