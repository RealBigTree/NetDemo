using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WEB.Areas.WX.WeChat {
    public class Helper {
        public static void Handle(string postStr) {
            //封装请求类    
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postStr);
            XmlElement rootElement = doc.DocumentElement;
            //MsgType    
            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");
            //接收的值--->接收消息类(也称为消息推送)    
            RequestXML requestXML = new RequestXML();
            requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
            requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
            requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
            requestXML.MsgType = MsgType.InnerText;

            //根据不同的类型进行不同的处理    
            switch (requestXML.MsgType) {
                case "text": //文本消息    
                    requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;
                    break;
                case "image": //图片    
                    requestXML.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                    break;
                case "location": //位置    
                    requestXML.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;
                    requestXML.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;
                    requestXML.Scale = rootElement.SelectSingleNode("Scale").InnerText;
                    requestXML.Label = rootElement.SelectSingleNode("Label").InnerText;
                    break;
                case "link": //链接    
                    break;
                case "event": //事件推送 支持V4.5+    
                    break;
            }

            //消息回复    
            ResponseMsg(requestXML);
        }

        private static void ResponseMsg(RequestXML requestXML) {
            try {
                string resxml = "";
                //主要是调用数据库进行关键词匹配自动回复内容，可以根据自己的业务情况编写。  
                //1.通常有，没有匹配任何指令时，返回帮助信息  
                // AutoResponse mi = new AutoResponse(requestXML.Content, requestXML.FromUserName);

                switch (requestXML.MsgType) {
                    case "text":
                        //在这里执行一系列操作，从而实现自动回复内容.   
                        // WriteLog(requestXML.Content);
                        resxml = "<xml><ToUserName><![CDATA[" + requestXML.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXML.ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + requestXML.Content + "]]></Content></xml>";
                        // resxml += mi.GetRePic(requestXML.FromUserName);

                        break;
                    case "location":

                        break;

                    case "image":
                        //图文混合的消息 具体格式请见官方API“回复图文消息”   
                        break;
                }

                System.Web.HttpContext.Current.Response.Write(resxml);
                //  WriteToDB(requestXML, resxml, mi.pid);
            } catch (Exception ex) {
                //WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());  
                //wx_logs.MyInsert("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());  
            }
        }
    }
}