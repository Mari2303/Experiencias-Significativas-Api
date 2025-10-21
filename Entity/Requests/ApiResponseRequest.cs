namespace Entity.Requests
{
    /// <summary>
    /// Representa una estructura estandarizada para las respuestas de la API.
    /// Incluye propiedades para el estado, mensaje y datos, permitiendo flexibilidad para devolver cualquier tipo de informaci�n.
    /// </summary>
    /// <typeparam name="T">El tipo de dato que se devuelve en la respuesta.</typeparam>
    public class ApiResponseRequest<T>
    {
        /// <summary>
        /// Obtiene o establece el estado de la petici�n. 
        /// Verdadero si la petici�n fue exitosa, Falso en caso contrario.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Obtiene o establece un mensaje personalizado que proporciona informaci�n adicional sobre la respuesta.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Obtiene o establece los datos devueltos en la respuesta.
        /// Puede ser una sola entidad o una lista de entidades dependiendo del tipo gen�rico <typeparamref name="T"/>.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApiResponseRequest{T}"/> con valores por defecto.
        /// Establece el estado en verdadero, el mensaje en "Ok" y los datos en su valor predeterminado.
        /// </summary>
        /// <param name="data">Los datos que se incluir�n en la respuesta (ignorados en este constructor).</param>
        public ApiResponseRequest(IEnumerable<DataSelectRequest> data)
        {
            Status = true;
            Message = "Ok";
            Data = default(T);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApiResponseRequest{T}"/> con la informaci�n proporcionada.
        /// </summary>
        /// <param name="data">Los datos que se incluir�n en la respuesta.</param>
        /// <param name="status">El estado de la petici�n (Verdadero o Falso).</param>
        /// <param name="message">Un mensaje personalizado que proporciona informaci�n adicional sobre la petici�n.</param>
        public ApiResponseRequest(T data, bool status, string message)
        {
            Data = data;
            Status = status;
            Message = message;
        }
    }
}
