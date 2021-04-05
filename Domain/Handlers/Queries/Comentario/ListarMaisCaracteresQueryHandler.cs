using Domain.Queries.Requests.Comentario;
using Domain.Repositories;
using Shared.Handlers;
using Shared.Queries;
using System;

namespace Domain.Handlers.Queries.Comentario
{
    public class ListarMaisCaracteresQueryHandler : IHandlerQuery<ListarMaisCaracteresQuery>
    {
        private IComentarioRepository Repositorio { get; set; }

        public ListarMaisCaracteresQueryHandler(IComentarioRepository repositorio)
        {
            Repositorio = repositorio;
        }

        public IQueryResult Handle(ListarMaisCaracteresQuery query)
        {
            try
            {
                var comentario = Repositorio.Buscar(query.IdComentario);

                var texto = comentario.Texto.Substring(query.De, (comentario.Texto.Length - query.De) > 50 ? 50 : comentario.Texto.Length - query.De);

                return new GenericQueryResult(200, "Mais caracteres!", texto);
            }
            catch (Exception ex)
            {
                return new GenericQueryResult(500, ex.Message, ex);
            }
        }
    }
}
