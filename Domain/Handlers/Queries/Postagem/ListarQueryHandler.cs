using System;
using System.Linq;
using Domain.Queries.Requests.Postagem;
using Domain.Queries.Responses.Comentarios;
using Domain.Queries.Responses.Postagens;
using Domain.Repositories;
using Shared.Handlers;
using Shared.Queries;

namespace Domain.Handlers.Queries.Postagem
{
    public class ListarQueryHandler : IHandlerQuery<ListarQuery>
    {
        private IPostagemRepository Repositorio { get; set; }

        public ListarQueryHandler(IPostagemRepository repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarQuery query)
        {
            try
            {
                var postagens = Repositorio.Listar(query.PalavrasChave)

                var result = new ListarQueryResult()
                {
                    QuantidadePostagens = postagens.ToList().Count,
                    Postagens = postagens
                            .Skip((query.Page - 1) * 10)
                            .Take(10)
                            .Select(
                            p => new PostagemGenericQueryResult()
                            {
                                Id = p.Id,
                                Texto = p.Texto.Length > 50 ? p.Texto.Substring(0, 50) + "..." : p.Texto,
                                DataCriacao = p.DataCriacao,
                                QuantidadeComentarios = p.Comentarios.Count,
                                Comentarios = p.Comentarios
                                        .OrderBy(c => c.DataCriacao)
                                        .Select(
                                        c => new ComentarioGenericQueryResult()
                                        {
                                            Id = c.Id,
                                            Texto = c.Texto.Length > 50 ? c.Texto.Substring(0, 50) : c.Texto,
                                            DataCriacao = c.DataCriacao,
                                            QuantidadeCaracteres = c.Texto.Length
                                        })
                                        .Take(5)
                                        .ToList()
                            })
                            .ToList()
                };

                if(postagens == null || result == null)
                    return new GenericQueryResult(404, "Nenhuma postagens encontrada!", null);

                return new GenericQueryResult(200, "Postagens!", result);
            }
            catch (Exception ex)
            {
                return new GenericQueryResult(500, ex.Message, ex);
            }
        }
    }
}