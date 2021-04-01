using Shared.Queries;

namespace Domain.Queries.Requests.Postagem
{
    public class ListarQuery : IQuery
    {
        public int Page { get; set; }
        public string PalavrasChave { get; set; }

        public ListarQuery(int page, string palavrasChave = null)
        {
            Page = page;
            if(palavrasChave != null)
                PalavrasChave = palavrasChave.ToLower().Trim();
        }

        public void Validar(){}
    }
}