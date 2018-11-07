using PaySharp.Core;
using PaySharp.Core.Request;
using System.Threading.Tasks;

namespace PaySharp.Wechatpay.Response
{
    public class PublicKeyResponse : BaseResponse
    {
        /// <summary>
        /// RSA 公钥
        /// </summary>
        [ReName(Name = "pub_key")]
        public string PublicKey { get; set; }

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
        }
    }
}
