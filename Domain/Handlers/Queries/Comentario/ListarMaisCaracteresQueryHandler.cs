using Domain.Queries.Requests.Comentario;
using Domain.Repositories;
using Shared.Handlers;
using Shared.Queries;

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
            var comentario = Repositorio.Buscar(query.IdComentario);

            var texto = comentario.Texto.Substring(query.De, (comentario.Texto.Length - query.De) > 50 ? 50 : comentario.Texto.Length - query.De);

            return new GenericQueryResult(true, null, texto);
        }
    }
}
