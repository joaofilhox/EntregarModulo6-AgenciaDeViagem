using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagem.Model
{
    [Table("destinos")]
    public class Destino
    {
        public int Id { get; set; }

        [Column("destino_name")]
        public string DestinoName { get; set; }

        [Column("destino_genre")]
        public string DestinoGenre { get; set; }

        [Column("destino_url")]
        public string DestinoURL { get; set; }

        [Column("destino_price")]
        public decimal DestinoPrice { get; set; }
    }
}
