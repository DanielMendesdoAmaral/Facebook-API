using Shared.Queries;
using System;

namespace Domain.Queries.Requests.Postagem
{
    public class ListarComentariosQuery : IQuery
    {
        public Guid IdPostagem { get; set; }
        public int De { get; set; }

        public ListarComentariosQuery(int de, Guid idPostagem)
        {
            De = de;
            IdPostagem = idPostagem;
        }

        public void Validar(){}
    }
}
