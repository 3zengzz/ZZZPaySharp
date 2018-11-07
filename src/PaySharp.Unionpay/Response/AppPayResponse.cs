using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Unionpay.Response
{
    public class AppPayResponse : BaseResponse
    {
        /// <summary>
        /// 银联受理订单号
        /// </summary>
        public string Tn { get; set; }

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {

        }
    }
}
