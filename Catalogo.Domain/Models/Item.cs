namespace CatalogoApp.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Consola { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public List<Resena> Resenas { get; set; } = new();

        public double CalificacionPromedio =>
            Resenas.Count == 0 ? 0 : Math.Round(Resenas.Average(r => r.Estrellas), 1);
    }
}