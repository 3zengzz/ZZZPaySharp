using PaySharp.Core.Response;
using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Response;
using System;

namespace PaySharp.Unionpay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayModel, BarcodePayResponse>
    {
        public BarcodePayRequest()
        {
            RequestUrl = "/gateway/api/backTransReq.do";
        }

        /// <summary>
        /// 轮询间隔,单位毫秒
        /// </summary>
        public int PollTime { get; set; } = 5000;

        /// <summary>
        /// 轮询次数
        /// </summary>
        public int PollCount { get; set; } = 10;

        internal override void Execute(Merchant merchant)
        {
            GatewayData.Remove("frontUrl");
        }
    }
}
