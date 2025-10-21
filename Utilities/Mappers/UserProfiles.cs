using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Utilities.JwtAuthentication;

namespace Utilities.Mappers
{
    /// <summary>
    /// Define un mapeador para usuarios que realiza la conversi�n entre entidades y objetos de transferencia de datos (DTOs).
    /// Esta clase configura los mapeos para el modelo User y sus correspondientes DTOs.
    /// </summary>
    public class UserProfiles : Profile
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UserProfiles"/> con el servicio de autenticaci�n JWT para cifrado de contrase�as.
        /// </summary>
        /// <param name="jwtAuthentication">El servicio de autenticaci�n JWT utilizado para cifrar las contrase�as mediante MD5.</param>
        public UserProfiles(IJwtAuthentication jwtAuthentication) : base()
        {
            _jwtAuthentication = jwtAuthentication;

            // Mapeo de UserDTO a User con cifrado de contrase�a
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            // Mapeo de User a UserDTO
            CreateMap<User, UserDTO>();

            // Mapeo de UserRequest a User con cifrado de contrase�a
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            // Mapeo de User a UserRequest
            CreateMap<User, UserRequest>();
        }
    }
}
