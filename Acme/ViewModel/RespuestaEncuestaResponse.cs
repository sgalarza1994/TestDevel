using System.Collections.Generic;

namespace Acme.ViewModel
{
    public class RespuestaEncuestaResponse
    {
        public int RespuestaId { get; set; }
        public string NombreEncuesta { get; set; }

        
        public string FechaRegistro { get; set; }

        public List<RespuestaEncuestaResponseDetalle> Items { get; set; }
    }

    public class RespuestaEncuestaResponseDetalle
    {
        public string NombreCampo { get; set; }
        public string Respuesta { get; set; }
    }

}
