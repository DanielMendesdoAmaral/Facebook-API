using Domain.Queries.Requests.Postagem;
using Domain.Queries.Responses.Comentarios;
using Domain.Repositories;
using Shared.Handlers;
using Shared.Queries;
using System;
using System.Linq;

namespace Domain.Handlers.Queries.Postagem
{
    public class ListarComentariosQueryHandler : IHandlerQuery<ListarComentariosQuery>
    {
        private IPostagemRepository Repositorio { get; set; }

        public ListarComentariosQueryHandler(IPostagemRepository repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarComentariosQuery query)
        {
            try
            {
                var comentarios = Repositorio.Buscar(query.IdPostagem).Comentarios.OrderBy(c => c.DataCriacao);

                var result = comentarios
                        .Skip(query.De)
                        .Take(5)
                        .Select(
                        c => new ComentarioGenericQueryResult()
                        {
                            Id = c.Id,
                            Texto = c.Texto.Length > 50 ? c.Texto.Substring(0, 50) : c.Texto,
                            DataCriacao = c.DataCriacao,
                            QuantidadeCaracteres = c.Texto.Length
                        });

                return new GenericQueryResult(200, "Mais comentários", result);
            }
            catch (Exception ex)
            {
                return new GenericQueryResult(500, ex.Message, ex);
            }
        }
    }
}
