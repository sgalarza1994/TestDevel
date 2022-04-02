using System.Collections.Generic;

namespace Acme.ViewModel
{
    public class EncuestaModficarRequest 
    {
        public int EncuestaId { get; set; }
        public string NombreEncuesta { get; set; }
        public string DescripcionEncuesta { get; set; }

        public List<CampoModificar> Items { get; set; }
        public Response IsValid()
        {
            if(EncuestaId <=0)
                return new Response { Success = false, Message = "Campo EncuestaId es requerido" };
            if (string.IsNullOrEmpty(NombreEncuesta))
                return new Response { Success = false, Message = "Campo NombreEncuesta es requerido" };

            if (string.IsNullOrEmpty(DescripcionEncuesta))
                return new Response { Success = false, Message = "Campo DescripcionEncuesta es requerido" };

            return new Response { Success = true, Message = "" };
        }
    }

    public class CampoModificar
    {
        public int CampoId { get; set; }
        public string NombreCampo { get; set; }
        public string TituloCampo { get; set; }
        public string Requerido { get; set; }

        public string TipoCampo { get; set; }
    }


}
