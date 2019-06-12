using System;
using System.Collections.Generic;
using System.Text;

namespace PaySharp.Core
{
    /// <summary>
    /// 同步回调成功处理
    /// </summary>
    public class ReturnEventArgs : NotifyEventArgs
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public ReturnEventArgs(BaseGateway gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
