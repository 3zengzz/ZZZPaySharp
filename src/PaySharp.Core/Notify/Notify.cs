using PaySharp.Core.Exceptions;
using PaySharp.Core.Utils;
using System;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    /// <summary>
    /// 网关返回的支付通知数据的接受
    /// </summary>
    public class Notify
    {
        #region 私有字段和构造函数

        private readonly IGateways _gateways;

        private readonly IPayNotify _payNotify;
        /// <summary>
        /// 初始化支付通知
        /// </summary>
        /// <param name="gateways">用于验证支付网关返回数据的网关列表</param>
        public Notify(IGateways gateways, IPayNotify payNotify)
        {
            _gateways = gateways;
            _payNotify = payNotify;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 接收并验证网关的支付通知
        /// </summary>
        public async Task ReceivedAsync(NotifyType notifyType)
        {
            var gateway = NotifyProcess.GetGateway(_gateways);
            if (gateway is NullGateway)
            {
                await _payNotify.OnUnknownGateway(new UnknownGatewayEventArgs(gateway));
                return;
            }

            try
            {
                if (!await gateway.ValidateNotifyAsync())
                {
                    await _payNotify.OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
                    {
                        Message = "签名验证失败"
                    });
                    await gateway.WriteFailureFlag();
                    return;
                }

                if (notifyType == NotifyType.Sync) //是否是同步回调
                {
                    await _payNotify.OnReturnNotify(new ReturnEventArgs(gateway));
                    return;
                }

                bool result = false;
                if (gateway.IsPaySuccess)
                {
                    result = await _payNotify.OnPaySucceed(new PaySucceedEventArgs(gateway));
                }
                else if (gateway.IsRefundSuccess)
                {
                    result = await _payNotify.OnRefundSucceed(new RefundSucceedEventArgs(gateway));
                }
                else if (gateway.IsCancelSuccess)
                {
                    result = await _payNotify.OnCancelSucceed(new CancelSucceedEventArgs(gateway));
                }
                else
                {
                    result = await _payNotify.OnUnknownNotify(new UnKnownNotifyEventArgs(gateway));
                }

                if (result)
                {
                    await gateway.WriteSuccessFlag();
                }
                else
                {
                    await gateway.WriteFailureFlag();
                }
            }
            catch (GatewayException ex)
            {
                await _payNotify.OnUnknownNotify(new UnKnownNotifyEventArgs(gateway)
                {
                    Message = ex.Message
                });
                await gateway.WriteFailureFlag();
            }
        }

        #endregion
    }
}