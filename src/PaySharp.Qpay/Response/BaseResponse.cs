﻿using PaySharp.Core;
using PaySharp.Core.Request;
using PaySharp.Core.Response;
using System.Threading.Tasks;

namespace PaySharp.Qpay.Response
{
    public abstract class BaseResponse : IResponse
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [ReName(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [ReName(Name = "retcode")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 手Q CGI原始错误码
        /// </summary>
        [ReName(Name = "retmsg")]
        public string RetCode { get; set; }

        /// <summary>
        /// 手Q CGI原始错误信息
        /// </summary>
        public string RetMsg { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        public string Raw { get; set; }

        internal GatewayData GatewayData { get; set; }

        internal abstract Task Execute<TModel, TResponse>(Merchant merchant, Request<TModel, TResponse> request) where TResponse : IResponse;
    }
}
