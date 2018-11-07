using PaySharp.Core.Request;
using PaySharp.Qpay.Domain;
using PaySharp.Qpay.Request;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaySharp.Qpay.Response
{
    public class BarcodePayResponse : QueryResponse
    {
        private Merchant _merchant;

        internal override async Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request)
        {
            _merchant = merchant;
            var barcodePayRequest = request as BarcodePayRequest;

            if (ResultCode == "SUCCESS")
            {
                return;
            }

            if (ErrCode == "USERPAYING")
            {
                var queryResponse = await PollQueryTradeStateAsync(
                        barcodePayRequest.Model.OutTradeNo,
                        barcodePayRequest.PollTime,
                        barcodePayRequest.PollCount);

                if (queryResponse != null)
                {
                    ResultCode = queryResponse.ResultCode;
                    return;
                }
                else
                {
                    ErrCodeDes = "支付超时";
                    return;
                }
            }

            throw new Exception(ErrCodeDes);
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private async Task<QueryResponse> PollQueryTradeState(string outTradeNo, int pollTime, int pollCount)
        {
            for (int i = 0; i < pollCount; i++)
            {
                var queryRequest = new QueryRequest();
                queryRequest.AddGatewayData(new QueryModel
                {
                    OutTradeNo = outTradeNo
                });
                var queryResponse = await SubmitProcess.Execute(_merchant, queryRequest);
                if (queryResponse.TradeState == "SUCCESS")
                {
                    return queryResponse;
                }
                Thread.Sleep(pollTime);
            }

            //支付超时，取消订单
            var cancelRequest = new CancelRequest();
            cancelRequest.AddGatewayData(new CancelModel
            {
                OutTradeNo = outTradeNo
            });
            await SubmitProcess.Execute(_merchant, cancelRequest);

            return null;
        }

        /// <summary>
        /// 轮询查询用户是否支付
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <param name="pollTime">轮询间隔</param>
        /// <param name="pollCount">轮询次数</param>
        /// <returns></returns>
        private Task<QueryResponse> PollQueryTradeStateAsync(string outTradeNo, int pollTime, int pollCount)
        {
            return PollQueryTradeState(outTradeNo, pollTime, pollCount);
        }
    }
}
