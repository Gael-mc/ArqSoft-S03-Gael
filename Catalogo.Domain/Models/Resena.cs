namespace CatalogoApp.Domain.Models
{
    public class Resena
    {
        public string Autor { get; set; } = "Anónimo";
        public string Texto { get; set; } = string.Empty;
        public int Estrellas { get; set; } = 5;
        public string Fecha { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
    }
}