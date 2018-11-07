using PaySharp.Core.Request;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Wechatpay.Response
{
    public class BillDownloadResponse : BaseResponse
    {
        /// <summary>
        /// 获取账单文件
        /// </summary>
        public byte[] GetBillFile()
        {
            return _billFile;
        }

        private byte[] _billFile;

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            if (!string.IsNullOrEmpty(Raw))
            {
                _billFile = Encoding.UTF8.GetBytes(Raw);
            }
        }
    }
}
