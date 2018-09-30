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

        Task<bool> OnPaySucceed(PaySucceedEventArgs args);

        Task<bool> OnRefundSucceed(RefundSucceedEventArgs args);

        Task<bool> OnCancelSucceed(CancelSucceedEventArgs args);

        Task<bool> OnUnknownNotify(UnKnownNotifyEventArgs args);

        Task OnUnknownGateway(UnknownGatewayEventArgs args);

    }
}
