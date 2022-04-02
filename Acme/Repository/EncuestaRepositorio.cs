using Acme.Model;
using Acme.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Repository
{
    public interface IEncuestaRepositorio
    {
        Task<Response> CrearEncuesta(EncuestaAddRequest add);
        Task<Response> ModificarEncuensta(EncuestaModficarRequest request);
        Task<Response> EliminarEncuesta(EliminarEncuestaRequest request);
    }
    public class EncuestaRepositorio : IEncuestaRepositorio
    {
        public EncuestaRepositorio(EncuentaDb db,
            Parametro parametro)
        {
            Db = db;
            Parametro = parametro;
        }

        public EncuentaDb Db { get; }
        public Parametro Parametro { get; }

        public async Task<Response> CrearEncuesta(EncuestaAddRequest add)
        {
            try
            {
                var identificador = $"{Parametro.UrlEncuesta}{Guid.NewGuid().ToString()}";
                var encuesta = new Encuesta
                {
                    Descripcion = add.DescripcionEncuesta,
                    Nombre = add.NombreEncuesta,
                    Estado = true,
                    Url = identificador,
                    Items = add.Items.Select(t=> new EncuestaDetalle
                    {
                        NombreCampo = t.NombreCampo,
                        Requerido = t.Requerido,
                        TipoCampo = t.TipoCampo,
                        TituloCampo = t.TituloCampo
                        
                    }).ToList()
                };
                await Db.Encuestas.AddAsync(encuesta);
                await Db.SaveChangesAsync();
                return new Response { Success=true, Message="Encuesta creada correctamente"};
            }
            catch (Exception e)
            {
                return new Response { Success=false, Message=e.Message };
            }
        }

        public async Task<Response> EliminarEncuesta(EliminarEncuestaRequest request)
        {
            try
            {
                var encuesta = await Db.Encuestas.Where(t => t.EncuestaId == request.EncuestaId).FirstOrDefaultAsync();
                if (encuesta == null)
                    return new Response { Success = false, Message = "Error en obtener la encuesta" };

                encuesta.Estado = false;
                await Db.SaveChangesAsync();

                return new Response { Success = true, Message = "Encuesta Elimanada" };

            }
            catch (Exception e)
            {

                return new Response { Success = false, Message = e.Message };
            }
        }

        public async Task<Response> ModificarEncuensta(EncuestaModficarRequest request)
        {
            using var ts = await Db.Database.BeginTransactionAsync();
            try
            {
                var encuesta = await Db.Encuestas.Where(t => t.EncuestaId == request.EncuestaId).FirstOrDefaultAsync();
                if (encuesta == null)
                    return new Response { Success = false, Message = "No se encuentro la encuesta" };

                encuesta.Nombre = request.NombreEncuesta;
                encuesta.Descripcion = request.DescripcionEncuesta;
                await Db.SaveChangesAsync();
                if(request.Items.Count > 0)
                {
                    foreach (var item in request.Items)
                    {
                        if(item.CampoId <=0)
                        {
                            await Db.EncuestaDetalles.AddAsync(new EncuestaDetalle
                            {
                                EncuestaId = encuesta.EncuestaId,
                                NombreCampo = item.NombreCampo,
                                Requerido = item.Requerido,
                                TituloCampo= item.TituloCampo,
                                TipoCampo = item.TipoCampo,
                            });
                        }
                        else
                        {
                            var detalle = await Db.EncuestaDetalles.Where(t => t.EncuestaDetalleId == item.CampoId).FirstOrDefaultAsync();
                            if(detalle != null)
                            {
                                detalle.TipoCampo = item.TipoCampo;
                                detalle.Requerido = item.Requerido;
                                detalle.NombreCampo = item.NombreCampo;
                                detalle.TituloCampo = item.TituloCampo;
                            }
                        }
                        await Db.SaveChangesAsync();
                    }
                }

                await ts.CommitAsync();
                return new Response { Success = true, Message = "Modificacion exitosa" };

            }
            catch (Exception e)
            {
                await ts.RollbackAsync();
                return new Response { Success = false, Message = e.Message };
            }
        }
    }
}
