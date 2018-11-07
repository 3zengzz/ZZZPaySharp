using PaySharp.Alipay.Domain;
using PaySharp.Alipay.Response;
using PaySharp.Core.Response;
using System;

namespace PaySharp.Alipay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayModel, BarcodePayResponse>
    {
        public BarcodePayRequest()
            : base("alipay.trade.pay")
        {
        }

        /// <summary>
        /// 轮询间隔,单位毫秒
        /// </summary>
        public int PollTime { get; set; } = 5000;

        /// <summary>
        /// 轮询次数
        /// </summary>
        public int PollCount { get; set; } = 10;
    }
}
