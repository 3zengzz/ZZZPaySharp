using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Unionpay.Response
{
    public class ScanPayResponse : BaseResponse
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string QrCode { get; set; }

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
