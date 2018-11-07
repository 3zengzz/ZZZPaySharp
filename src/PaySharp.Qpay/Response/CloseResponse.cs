using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Qpay.Response
{
    public class CloseResponse : BaseResponse
    {
        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
