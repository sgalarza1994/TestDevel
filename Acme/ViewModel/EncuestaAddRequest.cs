using System.Collections.Generic;

namespace Acme.ViewModel
{
    public class EncuestaAddRequest
    {
        public string NombreEncuesta { get; set; }  
        public string DescripcionEncuesta { get; set; }

        public List<CampoAdd> Items { get; set; }
        public Response IsValid()
        {
            if (string.IsNullOrEmpty(NombreEncuesta))
                return new Response { Success = false, Message = "Campo NombreEncuesta es requerido" };

            if (string.IsNullOrEmpty(DescripcionEncuesta))
                return new Response { Success = false, Message = "Campo DescripcionEncuesta es requerido" };

            if (Items.Count == 0)
                return new Response { Success = false, Message = "Debe agregar Campos a la encuesta" };

            foreach (var item in Items)
            {
                if(string.IsNullOrEmpty(item.NombreCampo))
                    return new Response { Success = false, Message = "Campo NombreCampo requerido" };
                if (string.IsNullOrEmpty(item.TituloCampo))
                    return new Response { Success = false, Message = "Campo TituloCampo requerido" };
                if (string.IsNullOrEmpty(item.Requerido))
                    return new Response { Success = false, Message = "Campo Requerido requerido" };
                if (string.IsNullOrEmpty(item.TipoCampo))
                    return new Response { Success = false, Message = "Campo TipoCampo requerido" };
            }


            return new Response { Success = true, Message = "" };
        }
    }

    public class CampoAdd
    {
        public string NombreCampo { get; set; }
        public string TituloCampo { get; set; }
        public string Requerido { get; set; }

        public string TipoCampo { get; set; }
    }
}
