using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
  
    public interface IPersonRepository : IBaseModelRepository<Person, PersonDTO, PersonRequest>
    {
       
    }
}