#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using PaySharp.Core;
using PaySharp.Core.Response;
using PaySharp.Unionpay;
using PaySharp.Unionpay.Domain;
using PaySharp.Unionpay.Request;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Demo.Controllers
{
    public class UnionpayController : Controller
    {
        private readonly IGateway _gateway;

        public UnionpayController(IGateways gateways)
        {
            _gateway = gateways.Get<UnionpayGateway>();
        }

        [HttpPost]
        public async Task<ActionResult> WebPay(string order_id, int total_amount)
        {
            var request = new WebPayRequest();
            request.AddGatewayData(new WebPayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });

            var response =await _gateway.Execute(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public async Task<ActionResult> WapPay(string order_id, int total_amount)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });

            var response =await _gateway.Execute(request);
            return Content(response.Html, "text/html", Encoding.UTF8);
        }

        [HttpPost]
        public async Task<ActionResult> AppPay(string order_id, int total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OrderId = order_id
            });

            var response =await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ScanPay(string order_id, int total_amount)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id
            });

            var response =await _gateway.Execute(request);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BarcodePay(string order_id, string qr_no, int total_amount)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                TotalAmount = total_amount,
                OrderId = order_id,
                QrNo = qr_no
            });
            var response =await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Query(string order_id, string query_id)
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                OrderId = order_id,
                QueryId = query_id
            });

            var response =await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Refund(string order_id, int refund_amount, string orig_qry_id, string orig_order_id)
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                OrderId = order_id,
                RefundAmount = refund_amount,
                OrigOrderId = orig_order_id,
                OrigQryId = orig_qry_id
            });

            var response =await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Cancel(string order_id, int cancel_amount, string orig_qry_id, string orig_order_id)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                OrderId = order_id,
                CancelAmount = cancel_amount,
                OrigOrderId = orig_order_id,
                OrigQryId = orig_qry_id
            });

            var response =await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BillDownload(string bill_date)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date
            });

            var response =await _gateway.Execute(request);
            return File(response.GetBillFile(), "application/zip");
        }
    }
}
