using System.Collections.Generic;

namespace Acme.ViewModel
{
    public class EncuestaRepuestaRequest
    {
        public int EncuestaId { get; set; }
        public List<EncuestaRepuestaDetalleRequest> Items { get;set; }


        public Response IsValid()
        {
            if (EncuestaId <=0)
                return new Response { Success = false, Message = "Campo EncuestaId es requerido" };

            if (Items.Count == 0)
                return new Response { Success = false, Message = "Debe agregar Campos a la encuesta" };

            foreach (var item in Items)
            {
                if (item.CampoId <=0)
                    return new Response { Success = false, Message = "Campo CampoId requerido" };
                if (string.IsNullOrEmpty(item.Respuesta))
                    return new Response { Success = false, Message = "Campo Respuesta requerido" };
            }


            return new Response { Success = true, Message = "" };
        }

    }

    public class EncuestaRepuestaDetalleRequest
    {
        public int CampoId { get; set; }
        public string Respuesta { get; set; }
    }
}
