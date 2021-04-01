using System.Collections.Generic;

namespace Domain.Queries.Responses.Postagens
{
    public class ListarQueryResult
    {
        public int QuantidadePostagens { get; set; }
        public List<PostagemGenericQueryResult> Postagens { get; set; }
    }
}