using Domain.Handlers.Queries.Comentario;
using Domain.Queries.Requests.Comentario;
using Microsoft.AspNetCore.Mvc;
using Shared.Queries;
using System;

namespace Api.Controllers
{
    [Route("comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        [HttpGet("idComentario={idComentario}&de={de}")]
        public IQueryResult Get(Guid idComentario, int de, [FromServices] ListarMaisCaracteresQueryHandler handler)
        {
            var query = new ListarMaisCaracteresQuery(idComentario, de);

            return handler.Handle(query);
        }
    }
}
