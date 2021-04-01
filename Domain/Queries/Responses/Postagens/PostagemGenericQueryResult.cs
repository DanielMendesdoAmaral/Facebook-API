using System;
using System.Collections.Generic;
using Domain.Queries.Responses.Comentarios;

namespace Domain.Queries.Responses.Postagens
{
    public class PostagemGenericQueryResult
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeComentarios { get; set; }
        public List<ComentarioGenericQueryResult> Comentarios { get; set; }
    }
}