#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using PaySharp.Alipay.Response;
using PaySharp.Core;
using System.Threading.Tasks;

namespace PaySharp.Demo.Controllers
{
    public class NotifyController : Controller
    {
        private readonly IGateways _gateways;
        private readonly IPayNotify _payNotify;

        public NotifyController(IGateways gateways, IPayNotify payNotify)
        {
            _gateways = gateways;
            _payNotify = payNotify;
        }

        public async Task Index()
        {
            // 订阅支付通知事件
            Notify notify = new Notify(_gateways, _payNotify);

            // 接收并处理支付通知
            await notify.ReceivedAsync();
            
            if (!string.IsNullOrEmpty(_payNotify.RedirectPath)) //同步回调跳转
            {
                Response.Redirect(_payNotify.RedirectPath);
            }
        }
    }
}
