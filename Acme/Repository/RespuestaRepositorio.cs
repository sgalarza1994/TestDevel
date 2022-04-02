using Acme.Model;
using Acme.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Repository
{

    public interface IRepuestaRepositorio
    {
        Task<Response> AgregarRespuesta(EncuestaRepuestaRequest request);
        Task<Response<List<RespuestaEncuestaResponse>>> ObtenerResultado();
    }
    public class RespuestaRepositorio : IRepuestaRepositorio
    {
        public RespuestaRepositorio(EncuentaDb db)
        {
            Db = db;
        }

        public EncuentaDb Db { get; }

        public async Task<Response> AgregarRespuesta(EncuestaRepuestaRequest request)
        {
            try
            {
                var enc = new EncuestaRepuesta
                {
                    EncuestaId = request.EncuestaId,
                    FechaRegistro = DateTime.Now,
                    Items = request.Items.Select(t=> new EncuestaRespuestaDetalle
                    {
                        CampoId = t.CampoId,
                        Respuesta  = t.Respuesta
                    }).ToList()
                };
                await Db.EncuestaRepuestas.AddAsync(enc);
                await Db.SaveChangesAsync();
                return new Response { Success = true, Message = "Registro exitoso" };
            }
            catch (Exception e)
            {
                return new Response { Success = false, Message = e.Message };
            }
        }

        public async Task<Response<List<RespuestaEncuestaResponse>>> ObtenerResultado()
        {
            try
            {
                var rsp = await Db.EncuestaRepuestas.Include(t => t.Encuesta)
                                .Include(t => t.Items).ThenInclude(t => t.Campo)
                                .Select(t => new RespuestaEncuestaResponse
                                {
                                    FechaRegistro = t.FechaRegistro.ToString("yyyy-MM-dd"),
                                    NombreEncuesta = t.Encuesta.Nombre,
                                    RespuestaId  = t.EncuestaRespuestaId,
                                    Items = t.Items.Select(d=> new RespuestaEncuestaResponseDetalle
                                    {
                                        NombreCampo = d.Campo.NombreCampo,
                                        Respuesta = d.Respuesta

                                    }).ToList()

                                }).ToListAsync();

                return new Response<List<RespuestaEncuestaResponse>> { Success = rsp.Count > 0, Result = rsp };
            }
            catch (Exception e)
            {

                return new Response<List<RespuestaEncuestaResponse>> { Success = false, Message = e.Message };
            }
        }
    }
}
