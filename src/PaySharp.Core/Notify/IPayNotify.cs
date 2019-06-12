using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Core
{
    public interface IPayNotify
    {
        string RedirectPath { get; set; }

        /// <summary>
        /// 异步回调成功
        /// </summary>       
        Task<bool> OnPaySucceed(PaySucceedEventArgs args);

        /// <summary>
        ///同步支付成功回调
        /// </summary>       
        Task<bool> OnReturnNotify(ReturnEventArgs e);

        /// <summary>
        ///退款成功
        /// </summary>       
        Task<bool> OnRefundSucceed(RefundSucceedEventArgs args);

        Task<bool> OnCancelSucceed(CancelSucceedEventArgs args);

        Task<bool> OnUnknownNotify(UnKnownNotifyEventArgs args);

        Task OnUnknownGateway(UnknownGatewayEventArgs args);

    }
}
