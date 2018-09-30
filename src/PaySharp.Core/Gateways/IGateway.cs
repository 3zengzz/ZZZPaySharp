using PaySharp.Core.Request;
using PaySharp.Core.Response;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    public interface IGateway
    {
        Task<TResponse> Execute<TModel, TResponse>(Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
