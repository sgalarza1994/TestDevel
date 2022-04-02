namespace Acme.ViewModel
{
    public class EliminarEncuestaRequest
    {
        public int EncuestaId { get; set; }

        public Response IsValid()
        {
            if (EncuestaId <= 0)
                return new Response { Success = false, Message = "Campo EncuestaId es requerido" };

            return new Response { Success = true, Message = "" };
        }
    }
}
