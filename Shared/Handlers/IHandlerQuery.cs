using Shared.Queries;

namespace Shared.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handle(T query);
    }
}