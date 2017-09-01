using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unity.Base {
    public static class ExString {
        #region 增



        #endregion

        #region 删



        #endregion

        #region 改



        #endregion

        #region 查



        #endregion

        #region 转



        #endregion

        #region 其它

        /// <summary>
        /// 拆分字符串
        /// </summary>
        /// <param name="srcStr"></param>
        /// <param name="splitStr"></param>
        /// <param name="sso"></param>
        /// <returns></returns>
        public static List<string> Split(this String srcStr, string splitStr, StringSplitOptions sso = StringSplitOptions.RemoveEmptyEntries) {
            return srcStr.Split(splitStr.ToCharArray(), sso).ToList();
        }

        #endregion

    }
}
