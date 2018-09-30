using PaySharp.Alipay.Response;
using PaySharp.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaySharp.Demo.Controllers
{
    /// <summary>
    /// 支付回调
    /// </summary>
    public class PayNotify : IPayNotify
    {
        public string RedirectPath { get; set; }

        /// <summary>
        /// 支付成功处理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<bool> OnPaySucceed(PaySucceedEventArgs args)
        {
            // 支付成功时时的处理代码
            /* 建议添加以下校验。
             * 1、需要验证该通知数据中的OutTradeNo是否为商户系统中创建的订单号，
             * 2、判断Amount是否确实为该订单的实际金额（即商户订单创建时的金额），
             */
            if (args.GatewayType == typeof(Alipay.AlipayGateway))
            {
                var alipayNotifyResponse = (NotifyResponse)args.NotifyResponse;

                //同步通知，即浏览器跳转返回
                if (args.NotifyType == NotifyType.Sync)
                {
                    RedirectPath = ""; //给地址赋值
                }
            }

            //处理成功返回true
            return true;
        }

        /// <summary>
        /// 取消订单处理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<bool> OnCancelSucceed(CancelSucceedEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 成功退款处理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<bool> OnRefundSucceed(RefundSucceedEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 未知网关处理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task OnUnknownGateway(UnknownGatewayEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 未知回调处理
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<bool> OnUnknownNotify(UnKnownNotifyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
