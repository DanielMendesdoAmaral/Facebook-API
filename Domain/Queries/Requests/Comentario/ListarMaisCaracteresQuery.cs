using Shared.Queries;
using System;

namespace Domain.Queries.Requests.Comentario
{
    public class ListarMaisCaracteresQuery : IQuery
    {
        public Guid IdComentario { get; set; }
        public int De { get; set; }

        public ListarMaisCaracteresQuery(Guid idComentario, int de)
        {
            IdComentario = idComentario;
            De = de;
        }

        public void Validar() { }
    }
}
