using Entity.Models;
using Entity.Requests;
using Entity.Resquest;

namespace Repository.Interfaces
{
    /// <summary>
    /// Define las operaciones de autenticaci�n y manejo de credenciales de usuario.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Realiza el inicio de sesi�n de un usuario validando sus credenciales.
        /// </summary>
        /// <param name="username">El nombre de usuario de la persona que intenta iniciar sesi�n.</param>
        /// <param name="password">La contrase�a del usuario.</param>
        /// <returns>
        /// Una tarea asincr�nica que devuelve un objeto <see cref="UserLoginResponseRequest"/> 
        /// con el token JWT y la informaci�n del usuario si las credenciales son v�lidas, 
        /// o un error en caso contrario.
        /// </returns>
        Task<UserLoginResponseRequest> LoginAsync(string username, string password);

        /// <summary>
        /// Cambia la contrase�a de un usuario existente.
        /// </summary>
        /// <param name="changePassword">Objeto que contiene el ID del usuario y la nueva contrase�a.</param>
        /// <returns>
        /// Una tarea asincr�nica que representa la operaci�n de cambio de contrase�a.
        /// </returns>
        Task ChangePasswordAsync(ChangePasswordRequest changePassword);

        /// <summary>
        /// Obtiene la informaci�n del usuario a partir de un token JWT v�lido.
        /// </summary>
        /// <param name="token">El token JWT v�lido que contiene los datos del usuario.</param>
        /// <returns>
        /// Una tarea asincr�nica que devuelve el objeto <see cref="User"/> correspondiente al token proporcionado.
        /// </returns>
        Task<User> GetUserFromTokenAsync(string token);

        /// <summary>
        /// Renueva un token JWT existente, creando un nuevo token con los mismos "claims"
        /// pero con una nueva fecha de expiraci�n.
        /// </summary>
        /// <param name="token">El token JWT existente que se desea renovar.</param>
        /// <returns>
        /// Una tarea asincr�nica que devuelve un objeto <see cref="RenewTokenRequest"/> 
        /// con la informaci�n del nuevo token generado.
        /// </returns>
        Task<RenewTokenRequest> RenewTokenAsync(string token);
    }
}
