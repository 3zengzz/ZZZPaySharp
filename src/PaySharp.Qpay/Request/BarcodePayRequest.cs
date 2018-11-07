using PaySharp.Core.Response;
using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Response;
using System;

namespace PaySharp.Qpay.Request
{
    public class BarcodePayRequest : BaseRequest<BarcodePayModel, BarcodePayResponse>
    {
        public BarcodePayRequest()
        {
            RequestUrl = "/cgi-bin/pay/qpay_micro_pay.cgi";
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
