namespace Shared.Queries
{
    public class GenericQueryResult : IQueryResult
    {
        public int StatusCode { get; private set; }
        public string Mensagem { get; private set; }
        public object Dados { get; private set; }

        public GenericQueryResult(int statusCode, string mensagem, object dados)
        {
            StatusCode = statusCode;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}