using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Alipay.Response
{
    public class CloseResponse : BaseResponse
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
