
using System.ComponentModel.DataAnnotations;

namespace PersonasRegisterApp.Models
{
    public class Contacto
    {
        [Key]
        public int ContactoId { get; set; }

        public string? PersonaDocumentoIdentidad { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string DireccionFisica { get; set; }

        [Phone]
        public string NumeroTelefonico { get; set; }

        public Persona? Persona { get; set; }
    }
}
