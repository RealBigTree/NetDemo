using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Unity.WX {
    public class WXHelper {
        //public static bool CheckSignature(string token) {
        //    string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];
        //    string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];
        //    string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];
        //    //加密/校验流程：    
        //    //1. 将token、timestamp、nonce三个参数进行字典序排序    
        //    string[] ArrTmp = { token, timestamp, nonce };
        //    Array.Sort(ArrTmp);//字典排序    
        //    //2.将三个参数字符串拼接成一个字符串进行sha1加密
        //    string tmpStr = string.Join("", ArrTmp);
        //    using (SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider()) {
        //        tmpStr = BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(tmpStr))).Replace("-", "").ToLower();
        //    }
        //    tmpStr = tmpStr.ToLower();
        //    //3.开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。    
        //    if (tmpStr == signature) {
        //        return true;
        //    } else {
        //        return false;
        //    }
        //}
    }
}
