using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;
using Utilities.Email.Interfaces;

namespace Service.Implementations
{

    public class UserService : BaseModelService<User, UserDTO, UserRequest>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;


        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IEmailService emailService) : base(userRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _emailService = emailService;
        }


        public async Task<UserRequest> GetByName(string name)
        {
            return await _userRepository.GetByName(name);
        }




        private string EncryptMD5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }




        public async Task<List<MenuRequest>> GetMenuAsync(int userId)
        {
            // Obtenemos el menú directo desde el UserRepository
            var menuItems = await _userRepository.GetMenuAsync(userId);

            // No necesitamos agrupar, solo devolvemos la lista tal cual
            return menuItems;
        }







        public async Task SendRecoveryCodeAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            if (user.Person == null || string.IsNullOrEmpty(user.Person.Email))
                throw new Exception("Usuario no tiene correo registrado");

            // Generar código de 6 dígitos
            var code = new Random().Next(100000, 999999).ToString();

            // Guardar código y expiración en User
            user.RecoveryCode = code;
            user.RecoveryCodeExpiration = DateTime.UtcNow.AddMinutes(10);

            await _userRepository.UpdateAsync(user);

            // Enviar correo usando tu EmailService
            await _emailService.SendExperiencesEmail(user.Person.Email, code);
        }

        public async Task ResetPasswordAsync(string email, string code, string newPassword)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            // Validar código y expiración
            if (user.RecoveryCode != code || user.RecoveryCodeExpiration == null || user.RecoveryCodeExpiration < DateTime.UtcNow)
                throw new Exception("Código inválido o expirado");



            // Encriptar la contraseña con MD5
            user.Password = EncryptMD5(newPassword);

            // Limpiar código de recuperación
            user.RecoveryCode = null;
            user.RecoveryCodeExpiration = null;

            await _userRepository.UpdateAsync(user);


        }




    }
}


