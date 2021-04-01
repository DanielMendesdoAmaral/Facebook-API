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
        public IQueryResult Get([FromServices] ListarQueryHandler handler, int page, string palavrasChave = null)
        {
            var query = new ListarQuery(page);
            if (palavrasChave != null)
                query.PalavrasChave = palavrasChave;
            return handler.Handle(query);
        }

        [HttpGet("idPostagem={idPostagem}&de={de}")]
        public IQueryResult Get([FromServices] ListarComentariosQueryHandler handler, int de, Guid idPostagem)
        {
            var query = new ListarComentariosQuery(de, idPostagem);
            return handler.Handle(query);
        }
    }
}