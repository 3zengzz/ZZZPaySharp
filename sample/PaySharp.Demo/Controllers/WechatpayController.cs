﻿using PaySharp.Core;
using PaySharp.Core.Response;
using PaySharp.Wechatpay;
using PaySharp.Wechatpay.Domain;
using PaySharp.Wechatpay.Request;
using System.Threading.Tasks;
#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif
using System;

namespace PaySharp.Demo.Controllers
{
    public class WechatpayController : Controller
    {
        private readonly IGateway _gateway;

        public WechatpayController(IGateways gateways)
        {
            _gateway = gateways.Get<WechatpayGateway>();
        }

        [HttpPost]
        public async Task<ActionResult> PublicPay(string out_trade_no, int total_amount, string body, string open_id)
        {
            var request = new PublicPayRequest();
            request.AddGatewayData(new PublicPayModel()
            {
                Body = body,
                OutTradeNo = out_trade_no,
                TotalAmount = total_amount,
                OpenId = open_id,
                TimeExpire = DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss")
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> AppPay(string out_trade_no, int total_amount, string body)
        {
            var request = new AppPayRequest();
            request.AddGatewayData(new AppPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> AppletPay(string out_trade_no, int total_amount, string body, string open_id)
        {
            var request = new AppletPayRequest();
            request.AddGatewayData(new AppletPayModel()
            {
                Body = body,
                OutTradeNo = out_trade_no,
                TotalAmount = total_amount,
                OpenId = open_id
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> WapPay(string out_trade_no, int total_amount, string body, string scene_info)
        {
            var request = new WapPayRequest();
            request.AddGatewayData(new WapPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no,
                SceneInfo = scene_info
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ScanPay(string out_trade_no, string body, int total_amount)
        {
            var request = new ScanPayRequest();
            request.AddGatewayData(new ScanPayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BarcodePay(string out_trade_no, string auth_code, int total_amount, string body)
        {
            var request = new BarcodePayRequest();
            request.AddGatewayData(new BarcodePayModel()
            {
                Body = body,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no,
                AuthCode = auth_code,
                TimeExpire = DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss")
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Query(string out_trade_no, string trade_no)
        {
            var request = new QueryRequest();
            request.AddGatewayData(new QueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Refund(string out_trade_no, string trade_no, int total_amount, int refund_amount, string refund_desc, string out_refund_no)
        {
            var request = new RefundRequest();
            request.AddGatewayData(new RefundModel()
            {
                TradeNo = trade_no,
                RefundAmount = refund_amount,
                RefundDesc = refund_desc,
                OutRefundNo = out_refund_no,
                TotalAmount = total_amount,
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> RefundQuery(string out_trade_no, string trade_no, string out_refund_no, string refund_no)
        {
            var request = new RefundQueryRequest();
            request.AddGatewayData(new RefundQueryModel()
            {
                TradeNo = trade_no,
                OutTradeNo = out_trade_no,
                OutRefundNo = out_refund_no,
                RefundNo = refund_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Close(string out_trade_no)
        {
            var request = new CloseRequest();
            request.AddGatewayData(new CloseModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Cancel(string out_trade_no)
        {
            var request = new CancelRequest();
            request.AddGatewayData(new CancelModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> Transfer(string out_trade_no, string openid, string check_name, string true_name, int amount, string desc)
        {
            var request = new TransferRequest();
            request.AddGatewayData(new TransferModel()
            {
                OutTradeNo = out_trade_no,
                OpenId = openid,
                Amount = amount,
                Desc = desc,
                CheckName = check_name,
                TrueName = true_name
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> TransferQuery(string out_trade_no)
        {
            var request = new TransferQueryRequest();
            request.AddGatewayData(new TransferQueryModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> PublicKey()
        {
            var request = new PublicKeyRequest();

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> TransferToBank(string out_trade_no, string bank_no, string true_name, string bank_code, int amount, string desc)
        {
            var request = new TransferToBankRequest();
            request.AddGatewayData(new TransferToBankModel()
            {
                OutTradeNo = out_trade_no,
                BankNo = bank_no,
                Amount = amount,
                Desc = desc,
                BankCode = bank_code,
                TrueName = true_name
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> TransferToBankQuery(string out_trade_no)
        {
            var request = new TransferToBankQueryRequest();
            request.AddGatewayData(new TransferToBankQueryModel()
            {
                OutTradeNo = out_trade_no
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> BillDownload(string bill_date, string bill_type)
        {
            var request = new BillDownloadRequest();
            request.AddGatewayData(new BillDownloadModel()
            {
                BillDate = bill_date,
                BillType = bill_type
            });

            var response = await _gateway.Execute(request);
            return File(response.GetBillFile(), "text/csv", $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
        }

        [HttpPost]
        public async Task<ActionResult> FundFlowDownload(string bill_date, string account_type)
        {
            var request = new FundFlowDownloadRequest();
            request.AddGatewayData(new FundFlowDownloadModel()
            {
                BillDate = bill_date,
                AccountType = account_type
            });

            var response = await _gateway.Execute(request);
            return File(response.GetBillFile(), "text/csv", $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
        }

        [HttpPost]
        public async Task<ActionResult> OAuth(string code)
        {
            var request = new OAuthRequest();
            request.AddGatewayData(new OAuthModel()
            {
                Code = code
            });

            var response = await _gateway.Execute(request);
            return Json(response);
        }
    }
}
