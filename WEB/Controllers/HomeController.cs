using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.IO;
using System.Xml;
using System.Data;
using WEB.Areas.WX.WeChat;
using Unity.WX;
using System.Web.Security;
using System.Web.Script.Serialization;
using WEB.Com;
using System.Net;
using System.IO;

namespace WEB.Controllers {
    public class HomeController : Controller {
        //public ActionResult Index() {
        //    Debug.WriteLine(Request.Url);
        //    string str = Request.InputStream.ToString2();
        //    Debug.WriteLine(str);
        //    //Helper.Handle(str);
        //    //System.Web.HttpContext.Current.Response.Flush();
        //    var o = Content("<xml><ToUserName><![CDATA[o5GXwwm9RqHBbARxefZIIWL2Z6OI]]></ToUserName><FromUserName><![CDATA[gh_ee9755652670]]></FromUserName><CreateTime>2017/8/2 11:26:23</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[xxx爱你们! ]]></Content></xml>");
        //    //Debug.WriteLine(Response.OutputStream.ToString2());
        //    return o;
        //    ////if (WXHelper.CheckSignature("zyzyzy")) {
        //    //    string str = System.Web.HttpContext.Current.Request.QueryString["echoStr"];
        //    //    Debug.WriteLine(str);
        //    //    return Content(str);
        //    ////}
        //    ////return Content("");
        //}

        private string Token = "zyzyzy";

        public ActionResult Index() {
            if (Request.HttpMethod.ToLower() == "post") {
                if (CheckSignature()) {//验证服务器是否通过
                    GetMenuList();//加载菜单
                } else {
                    Response.Write("<h1>Oh</h1><h2>我们相遇在火星吧！！！</h2>");
                    Response.End();
                }
                //var o = Content("<xml><ToUserName><![CDATA[o5GXwwm9RqHBbARxefZIIWL2Z6OI]]></ToUserName><FromUserName><![CDATA[gh_ee9755652670]]></FromUserName><CreateTime>2017/8/2 11:26:23</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[xxx爱你们! ]]></Content></xml>");
                //return o;
            } else {
                CheckWechat();
            }
            return View();
        }

        /// <summary>
        /// 返回随机数表示验证成功
        /// </summary>
        private void CheckWechat() {
            if (string.IsNullOrEmpty(Request.QueryString["echoStr"])) {
                Response.Write("消息并非来自微信");
                Response.End();
            }
            string echoStr = Request.QueryString["echoStr"];
            if (CheckSignature()) {
                Response.Write(echoStr);
                Response.End();
            }
        }
        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// <returns></returns>
        /// 将token、timestamp、nonce三个参数进行字典序排序
        /// 将三个参数字符串拼接成一个字符串进行sha1加密
        /// 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        private bool CheckSignature() {
            string signature = Convert.ToString(Request["signature"]);
            string timestamp = Convert.ToString(Request["timestamp"]);
            string nonce = Convert.ToString(Request["nonce"]);
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);   //字典排序 
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature) {
                return true;
            } else {
                return false;
            }
        }

        public void GetMenuList() {
            string menu = "";
            menu = @" { 
     ""button"":[ 
     {   
          ""type"":""click"", 
          ""name"":""你好!"", 
          ""key"":""hello"" 
      }, 
      { 
           ""type"":""view"", 
           ""name"":""公司简介"", 
           ""url"":""http://www.baidu.com"" 
      }, 
      { 
           ""name"":""产品介绍"", 
           ""sub_button"":[ 
            { 
               ""type"":""click"", 
               ""name"":""产品1"", 
                ""key"":""p1"" 
            }, 
            { 
               ""type"":""click"", 
               ""name"":""产品2"", 
               ""key"":""p2"" 
            }] 
       }] 
 } 
";

            string access_token = WA_GetAccess_Token.IsExistAccess_Token();
            string i = MenuCreate(menu, access_token);
            Response.Write(i);
        }

        public string MenuCreate(string MenuJson, string access_token) {
            JavaScriptSerializer Jss = new JavaScriptSerializer();
            string setMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
            setMenuUrl = string.Format(setMenuUrl, access_token);//获取token、拼凑url
            string respText = WebRequestPostOrGet(setMenuUrl, MenuJson);
            Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(respText);
            return respDic["errcode"].ToString();//返回0发布成功
        }

        /// <summary>
        /// Post/get 提交调用抓取
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="param">参数</param>
        /// <returns>string</returns>
        public string WebRequestPostOrGet(string sUrl, string sParam) {
            byte[] bt = System.Text.Encoding.UTF8.GetBytes(sParam);

            Uri uriurl = new Uri(sUrl);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uriurl);//HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + (url.IndexOf("?") > -1 ? "" : "?") + param);
            req.Method = "Post";
            req.Timeout = 120 * 1000;
            req.ContentType = "application/x-www-form-urlencoded;";
            req.ContentLength = bt.Length;

            using (Stream reqStream = req.GetRequestStream()) {//using 使用可以释放using段内的内存
                reqStream.Write(bt, 0, bt.Length);
                reqStream.Flush();
            }
            try {
                using (WebResponse res = req.GetResponse()) {
                    //在这里对接收到的页面内容进行处理
                    Stream resStream = res.GetResponseStream();
                    StreamReader resStreamReader = new StreamReader(resStream, System.Text.Encoding.UTF8);
                    string resLine;
                    System.Text.StringBuilder resStringBuilder = new System.Text.StringBuilder();
                    while ((resLine = resStreamReader.ReadLine()) != null) {
                        resStringBuilder.Append(resLine + System.Environment.NewLine);
                    }
                    resStream.Close();
                    resStreamReader.Close();
                    return resStringBuilder.ToString();
                }
            } catch (Exception ex) {
                return ex.Message;//url错误时候回报错
            }
        }
    }
}