using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Wechatpay.Response
{
    public class CancelResponse : BaseResponse
    {
        /// <summary>
        /// 是否重调
        /// </summary>
        public string Recall { get; set; }

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
