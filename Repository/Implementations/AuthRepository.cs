using Entity.Models;
using Entity.Models.ModuleOperation;
using Entity.Requests;
using Entity.Resquest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Utilities.Helper.Implementation;
using Utilities.JwtAuthentication;

namespace Repository.Implementations
{
    /// <summary>
    /// Implementaci�n del repositorio de autenticaci�n para manejar inicio de sesi�n,
    /// registro y validaci�n de tokens.
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AuthRepository"/>.
        /// </summary>
        /// <param name="configuration">El servicio de configuraci�n de la aplicaci�n.</param>
        /// <param name="userRepository">Repositorio de usuarios para administrar los datos.</param>
        /// <param name="jwtAuthentication">Servicio de autenticaci�n JWT para generar y validar tokens.</param>
        public AuthRepository(IConfiguration configuration, IUserRepository userRepository, IJwtAuthentication jwtAuthentication)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _jwtAuthentication = jwtAuthentication;
        }

        /// <summary>
        /// Inicia sesi�n validando el nombre de usuario y la contrase�a, luego genera un token JWT.
        /// </summary>
        /// <param name="username">El nombre de usuario del usuario que intenta iniciar sesi�n.</param>
        /// <param name="password">La contrase�a del usuario.</param>
        /// <returns>
        /// Un objeto <see cref="UserLoginResponseRequest"/> que contiene los datos del usuario
        /// y el token JWT en caso de credenciales v�lidas.
        /// </returns>
        /// <exception cref="Exception">Lanza excepci�n si el nombre de usuario o la contrase�a son inv�lidos.</exception>
        public async Task<UserLoginResponseRequest> LoginAsync(string username, string password)
        {
            var encodePassword = _jwtAuthentication.EncryptMD5(password);
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("El nombre de usuario est� vac�o.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("La contrase�a est� vac�a.");
            }

            UserRequest user = await _userRepository.GetByName(username);
            List<string> roles = await _userRepository.GetRolesByUserId(user.Id);

            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }

            if (user.Password.ToUpper() != encodePassword.ToUpper())
            {
                throw new Exception("Contrase�a incorrecta.");
            }

            // Generar el token JWT
            var token = _jwtAuthentication.Authenticate(username, encodePassword, roles.FirstOrDefault(), user.Id);

            // Men�s a los que el usuario tiene acceso
            var menu = await _userRepository.GetMenuAsync(user.Id);

            return new UserLoginResponseRequest
            {
                UserId = user.Id,
                UserName = user.Person!,
                Email = user.Username,
                PersonId = user.PersonId,
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddHours(-3), 
                Menu = menu,
                Role = roles
            };
        }

        /// <summary>
        /// Cambia la contrase�a de un usuario, validando primero la contrase�a actual.
        /// </summary>
        /// <param name="dto">
        /// Objeto que contiene el ID del usuario, la contrase�a actual, 
        /// la nueva contrase�a y la confirmaci�n de la misma.
        /// </param>
        /// <returns>Una tarea asincr�nica que representa la operaci�n.</returns>
        /// <exception cref="Exception">
        /// Lanza excepci�n si el usuario no existe, si la contrase�a actual es incorrecta,
        /// o si la nueva contrase�a no coincide con la confirmaci�n.
        /// </exception>
        public async Task ChangePasswordAsync(ChangePasswordRequest dto)
        {
            // 1. Buscar usuario
            User user = await _userRepository.GetById(dto.UserId);

            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }

            // 2. Validar contrase�a actual
            string encryptedCurrent = _jwtAuthentication.EncryptMD5(dto.CurrentPassword);
            if (user.Password != encryptedCurrent)
            {
                throw new Exception("La contrase�a actual es incorrecta.");
            }

            // 3. Validar coincidencia entre nueva y confirmaci�n
            if (dto.NewPassword != dto.ConfirmPassword)
            {
                throw new Exception("Las contrase�as no coinciden.");
            }

            // 4. Validar seguridad de la nueva contrase�a
            PasswordHelper.ValidatePassword(dto.NewPassword);

            // 5. Encriptar y actualizar
            user.Password = _jwtAuthentication.EncryptMD5(dto.NewPassword);

            await _userRepository.Update(user);
        }

        /// <summary>
        /// Obtiene un usuario a partir de un token JWT v�lido.
        /// </summary>
        /// <param name="token">El token JWT usado para obtener los datos del usuario.</param>
        /// <returns>El objeto <see cref="User"/> correspondiente al token.</returns>
        public async Task<User> GetUserFromTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _userRepository.GetById(userId);
        }

        /// <summary>
        /// Renueva un token JWT existente creando uno nuevo con los mismos claims 
        /// pero con una nueva fecha de expiraci�n.
        /// </summary>
        /// <param name="token">El token JWT existente que se desea renovar.</param>
        /// <returns>
        /// Un objeto <see cref="RenewTokenRequest"/> con el nuevo token generado,
        /// o un error en caso de que la renovaci�n falle.
        /// </returns>
        public async Task<RenewTokenRequest> RenewTokenAsync(string token)
        {
            var newToken = _jwtAuthentication.RenewToken(token);
            return new RenewTokenRequest
            {
                Token = newToken
            };
        }
    }
}
