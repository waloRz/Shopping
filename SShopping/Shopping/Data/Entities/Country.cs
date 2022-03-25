using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

          // estas son Data anotetion
        [Display(Name = "Pais")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres ")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")] //Required hace que el campo sea obligatorio
        public string Name { get; set; }

        public ICollection<State> States { get; set; } // 1 pais tiene varios estados/provincias

        //                       operador ternario -> si la lista de estado es vacio me devuelve 0 sino state.count
        [Display(Name = "Provincias")]
        public int StatesNumber => States == null ? 0 : States.Count;    
    }
}
