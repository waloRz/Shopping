﻿using System.ComponentModel.DataAnnotations;

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

        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
