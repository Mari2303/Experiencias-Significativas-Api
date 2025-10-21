using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
 
    public interface IPersonService : IBaseModelService<Person, PersonDTO, PersonRequest>
    {
        Task<PersonRequest> CreatePersonAsync(PersonRequest request);
    }
}