using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Model
{
    public class Encuesta
    {
        [Key]
        public int EncuestaId { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Descripcion { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }


        public string Url { get; set; }
        public List<EncuestaDetalle> Items { get; set; }
    }
    
}
