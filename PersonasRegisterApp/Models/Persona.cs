
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonasRegisterApp.Models
{
    public class Persona
    {
        [Key]
        public string DocumentoIdentidad { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Los nombres solo pueden contener letras.")]
        public string Nombres { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Los apellidos solo pueden contener letras.")]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Contacto> Contactos { get; set; }
    }
}
