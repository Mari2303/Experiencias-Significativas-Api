namespace Entity.Requests
{
    /// <summary>
    /// Request utilizado para encapsular criterios de filtrado, ordenamiento y paginaci�n en consultas.
    /// </summary>
    public class QueryFilterRequest
    {
        /// <summary>
        /// N�mero de elementos por p�gina.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// N�mero de p�gina actual (basado en �ndice 1).
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Texto usado para filtrar resultados.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Nombre de la columna sobre la cual se aplicar� el filtro.
        /// </summary>
        public string? ColumnFilter { get; set; }

        /// <summary>
        /// Nombre de la columna utilizada para ordenar los resultados.
        /// </summary>
        public string? ColumnOrder { get; set; }

        /// <summary>
        /// Direcci�n del ordenamiento: "asc" (ascendente) o "desc" (descendente).
        /// </summary>
        public string? DirectionOrder { get; set; }

        /// <summary>
        /// Valor de clave for�nea opcional para filtrar entidades relacionadas.
        /// </summary>
        public int? ForeignKey { get; set; }

        /// <summary>
        /// Nombre de la propiedad de clave for�nea usada para filtrar.
        /// </summary>
        public string? NameForeignKey { get; set; }

        /// <summary>
        /// Indica si se debe aplicar paginaci�n (true o false).
        /// </summary>
        public bool AplyPagination { get; set; }

        /// <summary>
        /// Rol del usuario que realiza la consulta (para restricciones de acceso).
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Id del usuario que realiza la consulta (para restricciones de acceso).
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Si es true, solo trae entidades activas.
        /// </summary>
        public bool? OnlyState { get; set; }
    }
}
