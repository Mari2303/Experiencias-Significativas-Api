namespace Utilities.JwtAuthentication
{
    /// <summary>
    /// Interfaz que define operaciones para la autenticaci�n JWT y el cifrado de contrase�as.
    /// </summary>
    public interface IJwtAuthentication
    {
        /// <summary>
        /// Autentica a un usuario en funci�n de su nombre de usuario y contrase�a.
        /// </summary>
        /// <param name="user">El nombre de usuario del usuario.</param>
        /// <param name="password">La contrase�a del usuario.</param>
        /// <param name="role">El rol del usuario.</param>
        /// <param name="userId">El ID del usuario.</param>
        /// <returns>Un token JWT si la autenticaci�n es exitosa.</returns>
        string Authenticate(string user, string password, string role, int userId);

        /// <summary>
        /// Cifra una contrase�a utilizando el algoritmo MD5.
        /// </summary>
        /// <param name="password">La contrase�a a cifrar.</param>
        /// <returns>El hash MD5 de la contrase�a.</returns>
        string EncryptMD5(string password);

        /// <summary>
        /// Renueva un token JWT existente creando un nuevo token con los mismos claims pero con una nueva fecha de expiraci�n.
        /// </summary>
        /// <param name="existingToken">El token JWT existente que se desea renovar.</param>
        /// <returns>Un nuevo token JWT con los mismos claims pero con nueva fecha de expiraci�n, o un mensaje de error si la renovaci�n falla.</returns>
        string RenewToken(string existingToken);
    }
}
