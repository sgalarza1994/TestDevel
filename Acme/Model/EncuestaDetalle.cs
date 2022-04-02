using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Model
{
    public class EncuestaDetalle
    {
        [Key]
        public int EncuestaDetalleId { get; set; }

        [ForeignKey("EncuestaId")]
        public int EncuestaId { get; set; } 
        public Encuesta Encuesta { get; set; }

        [Column(TypeName ="varchar(200)")]
        public string NombreCampo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string TituloCampo { get; set; }
        [Column(TypeName ="varchar(1)")]
        public string Requerido { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TipoCampo { get; set; }
    }
}
