namespace ris_complejo_rest.Models
{
    public class ErrorTO
    {
        public ErrorTO() {
            this.mensaje = "OK";
            this.codigo = 0;
        }
        public string mensaje { get; set; }
        public int codigo { get; set; }
    }
}
