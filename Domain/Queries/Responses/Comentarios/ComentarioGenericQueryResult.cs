using System;

namespace Domain.Queries.Responses.Comentarios
{
    public class ComentarioGenericQueryResult
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeCaracteres { get; set; }
    }
}