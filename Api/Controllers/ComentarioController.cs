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
        public IActionResult Get(Guid idComentario, int de, [FromServices] ListarMaisCaracteresQueryHandler handler)
        {
            var query = new ListarMaisCaracteresQuery(idComentario, de);

            var result = (GenericQueryResult)handler.Handle(query);

            return result.StatusCode switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                500 => StatusCode(500, result),
                _ => null
            };
        }
    }
}
