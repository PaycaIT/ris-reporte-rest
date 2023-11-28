namespace ris_reporte_rest.Exceptions
{
    public class GestionIspeccionException:Exception
    {
        public int code { get; set; }
        public string userMessage { get; set; }
        public string action { get; set; }
    }
}
