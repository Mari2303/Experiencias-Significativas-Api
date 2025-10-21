namespace Entity.Requests
{
    /// <summary>
    /// Representa una petici�n de datos para selecci�n.
    /// Esta clase se utiliza para encapsular la informaci�n de los �tems que se mostrar�n en una lista de selecci�n o un men� desplegable.
    /// </summary>
    public class DataSelectRequest
    {
        /// <summary>
        /// Obtiene o establece el identificador �nico del �tem de selecci�n.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Obtiene o establece el texto que se mostrar� para el �tem de selecci�n.
        /// Este es el texto visible que aparecer� en una interfaz de selecci�n, como un men� desplegable o una lista.
        /// </summary>
        public string DisplayText { get; set; } = null!;
    }
}

