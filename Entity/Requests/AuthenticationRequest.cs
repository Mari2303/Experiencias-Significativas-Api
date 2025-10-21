namespace Entity.Requests
{
    /// <summary>
    /// Objeto de Transferencia de Datos (DTO) para la autenticaci�n de un usuario
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// El nombre de usuario �nico para la autenticaci�n
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// La contrase�a para la autenticaci�n del usuario
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
