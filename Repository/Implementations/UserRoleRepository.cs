using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Utilities.Helper;

namespace Repository.Implementations
{
    /// <summary>
    /// Implementación del repositorio para operaciones de asignación de usuarios a roles.
    /// </summary>
    public class UserRoleRepository : BaseModelRepository<UserRole, UserRoleDTO, UserRoleRequest>, IUserRoleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<UserRole, UserRoleDTO> _helperRepository;

        /// <summary>
        /// Constructor del repositorio de UserRole.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        /// <param name="mapper">Instancia de AutoMapper para mapeos.</param>
        /// <param name="configuration">Configuración de la aplicación (paginación, ordenamiento, etc.).</param>
        /// <param name="helperRepository">Helper genérico para manejo de entidades y DTOs.</param>
        public UserRoleRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<UserRole, UserRoleDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene una lista filtrada, ordenada y paginada de las asignaciones de usuarios a roles.
        /// </summary>
        /// <param name="filters">
        /// Instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales
        /// para filtrado, ordenamiento, paginación y restricciones por llave foránea.
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado es un <see cref="IEnumerable{UserRoleRequest}"/>
        /// con la lista de asignaciones usuario-rol que cumplen con los criterios aplicados.
        /// </returns>
        /// <exception cref="Exception">Lanza cualquier excepción encontrada durante la consulta o el mapeo.</exception>
        public override async Task<IEnumerable<UserRoleRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                // Configuración de paginación con valores por defecto
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0
                    ? filters.PageNumber.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageNumber");

                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0
                    ? filters.PageSize.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                // Configuración de ordenamiento con valores por defecto
                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                // SQL base con joins a Users y Roles
                var sql = @"SELECT
                                userRol.Id,
                                userRol.UserId,
                                userRol.RoleId,
                                u.Username AS UserName,
                                r.Name AS RoleName
                            FROM
                                UserRoles AS userRol
                            INNER JOIN Users AS u ON userRol.UserId = u.Id 
                            INNER JOIN Roles AS r ON userRol.RoleId = r.Id 
                            WHERE userRol.DeletedAt IS NULL ";

                // Filtro por ForeignKey (ej: UserId o RoleId)
                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND userRol." + filters.NameForeignKey + @" = @foreignKey ";
                }

                // Filtro de texto (por Username o Rol)
                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(u.Username, r.Name)) LIKE UPPER(CONCAT('%', @filter, '%'))) ";
                }

                // Ordenamiento dinámico
                sql += @"ORDER BY userRol." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                // Ejecutar consulta
                IEnumerable<UserRoleRequest> items = await _context.QueryAsync<UserRoleRequest>(
                    sql,
                    new { filter = filters.Filter, foreignKey = filters.ForeignKey }
                );

                // Aplicar paginación en memoria
                if (filters.AplyPagination)
                {
                    int skip = (pageNumber - 1) * pageSize;
                    items = items.Skip(skip).Take(pageSize);
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener UserRoles: {ex.Message}");
                throw;
            }
        }
    }
}

