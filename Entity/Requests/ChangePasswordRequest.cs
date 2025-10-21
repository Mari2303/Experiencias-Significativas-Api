using System.ComponentModel.DataAnnotations;

namespace Entity.Requests
{
    /// <summary>
    /// Petici�n para cambiar la contrase�a de un usuario
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>
        /// Identificador �nico del usuario
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Contrase�a actual del usuario (para verificaci�n)
        /// </summary>
        [Required(ErrorMessage = "La actual contrase�a es obligatoria")]
        public string CurrentPassword { get; set; } = string.Empty;

        /// <summary>
        /// Nueva contrase�a del usuario
        /// </summary>
        [Required(ErrorMessage = "La nueva contrase�a es obligatoria")]
        [MinLength(8, ErrorMessage = "La contrase�a debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Confirmaci�n de la nueva contrase�a
        /// </summary>
        [Required(ErrorMessage = "Debe confirmar la contrase�a")]
        [Compare("NewPassword", ErrorMessage = "Las contrase�as no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
