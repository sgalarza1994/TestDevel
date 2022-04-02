using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Model
{
    public class EncuestaRepuesta
    {
        [Key]
        public int EncuestaRespuestaId { get; set; }
        [ForeignKey("EncuestaId")]
        public int EncuestaId { get; set; }
        public Encuesta Encuesta { get; set; }
        public DateTime FechaRegistro { get; set; } 

        public List<EncuestaRespuestaDetalle> Items { get; set; }
    }
}
