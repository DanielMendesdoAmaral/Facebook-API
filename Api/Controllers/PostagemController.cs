using Domain.Handlers.Queries.Postagem;
using Domain.Queries.Requests.Postagem;
using Microsoft.AspNetCore.Mvc;
using Shared.Queries;
using System;

namespace Api.Controllers
{
    [Route("postagem")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        [HttpGet("page={page}")]
        public IActionResult Get([FromServices] ListarQueryHandler handler, int page, string palavrasChave = null)
        {
            var query = new ListarQuery(page);
            if (palavrasChave != null)
                query.PalavrasChave = palavrasChave;

            var result = (GenericQueryResult) handler.Handle(query);

            return result.StatusCode switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                500 => StatusCode(500, result),
                _ => null
            };
        }

        [HttpGet("idPostagem={idPostagem}&de={de}")]
        public IActionResult Get([FromServices] ListarComentariosQueryHandler handler, int de, Guid idPostagem)
        {
            var query = new ListarComentariosQuery(de, idPostagem);

            var result = (GenericQueryResult) handler.Handle(query);

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