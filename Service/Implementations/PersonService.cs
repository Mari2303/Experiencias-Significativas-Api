using Entity.Dtos;
using Entity.Enums;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;
using Utilities.Helper.Implementation;

namespace Service.Implementations
{
   
    public class PersonService : BaseModelService<Person, PersonDTO, PersonRequest>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
            _personRepository = personRepository;
        }



        // Método para crear persona desde PersonRequest
        public async Task<PersonRequest> CreatePersonAsync(PersonRequest request)
        {

            // Validar todos los campos
            PersonValidatorHelper.Validate(request);

            if (!Enum.TryParse<DocumentType>(request.DocumentType, out var docEnum))
            {
                throw new Exception("DocumentType inválido");
            }

            var entity = new Person
            {
                DocumentType = (int)docEnum,
                FirstName = request.FirstName,
                FirstLastName = request.FirstLastName,
                SecondLastName = request.SecondLastName,
                MiddleName = request.MiddleName,
                IdentificationNumber = request.IdentificationNumber,
                Email = request.Email,
                EmailInstitutional = request.EmailInstitutional,
                Phone = request.Phone,
                CodeDane = request.CodeDane,
               
            };

            var savedEntity = await _personRepository.Save(entity);
            request.Id = savedEntity.Id;
            return request;


        }
    }
}


