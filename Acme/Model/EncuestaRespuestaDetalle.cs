using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Model
{
    public class EncuestaRespuestaDetalle
    {
        [Key]
        public int EncuestaRespuestaDetalleId { get; set; }

        [ForeignKey("CampoId")]
        public int CampoId { get;set; }
        public EncuestaDetalle Campo { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Respuesta { get; set; }

        [ForeignKey("EncuestaRepuestaId")]
        public int EncuestaRepuestaId { get; set; }
        public EncuestaRepuesta EncuestaRepuesta { get; set; }
    }
}
