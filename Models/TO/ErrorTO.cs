namespace ris_reporte_rest.Models.TO
{
    public class ErrorTO
    {
        public ErrorTO()
        {
            mensaje = "OK";
        }
        public ErrorTO(int codigo, string mensaje)
        {
            this.codigo = codigo;
            this.mensaje = mensaje;
        }
        public string mensaje { get; set; }
        public int codigo { get; set; }
    }
}
