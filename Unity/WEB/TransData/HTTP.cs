using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unity.Base;

namespace Unity.WEB.TransData {
    public class HTTP {

        /// <summary>
        /// Get方式, 获取HTTP连接内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dicPara"></param>
        /// <returns></returns>
        public static string GetHttp(string url, Dictionary<string,object> dicPara = null) {
            if (dicPara != null || dicPara.Count > 0) {
                url += "?" + dicPara.ToStringFormat("=", "&");//
            }
            HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
            var xmlContent = sr.ReadToEnd().Trim();
            sr.Close();
            HttpWResp.Close();
            HttpWReq.Abort();
            return xmlContent;
        }

        /// <summary>
        /// Get方式, 获取HTTPS连接内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        //public static string GetHttps(string url, Dictionary<string, object> parameters = null) {
        //    var para = parameters.ToStringFormat("=", "&");
        //    url += "?" + para;//
        //    HttpWebRequest request;
        //    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((o, oo, ooo, oooo) => true);
        //    request = WebRequest.Create(url) as HttpWebRequest;
        //    request.ProtocolVersion = HttpVersion.Version10;
        //    request.Method = "GET";
        //    request.KeepAlive = false;
        //    request.UserAgent = "frf";
        //    request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
        //    HttpWebResponse rsp = (HttpWebResponse)request.GetResponse();
        //    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
        //    //return GetResponseString(rsp, encoding);
        //    return null;
        //}


    }
}
