using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    // Respuesta que devuelve el API de seguridad al hacer login
    public class Token
    {
        public bool ValidacionExitosa { get; set; }
        public string AccessToken { get; set; }
    }

    // Configuración leída de la sección "Token" en appsettings.json
    public class TokenConfiguracion
    {
        [Required]
        [StringLength(100, MinimumLength = 32)]
        public string key { get; set; } // Clave secreta para firmar tokens

        [Required]
        public string Issuer { get; set; } // Quién emite el token

        [Required]
        public double Expires { get; set; } // Minutos de vigencia

        [Required]
        public string Audience { get; set; } // Para quién es válido
    }
}
