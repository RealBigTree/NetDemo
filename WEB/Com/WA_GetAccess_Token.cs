using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml;

namespace WEB.Com {
    /// <summary>
/// 防止每次请求的token两个小时的变化
/// </summary>
public class WA_GetAccess_Token
{
    public WA_GetAccess_Token()
    {
    }

    public static Access_token GetAccess_Token() {
        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + "wxcbe87bb4937385db" + "&secret=" + "1d380d569f1bb50f80b29d6ed21d4e4c";
        Access_token entity = new Access_token();
        try {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse()) {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string content = reader.ReadToEnd();
                Access_token token = new Access_token();
                token = JsonHelper.ParseFromJson<Access_token>(content);
                entity.access_token = token.access_token;
                entity.expires_in = token.expires_in;
            }
        } catch { //记录日志}
            return entity;
        }
        return entity;
    }
 
 
    /// <summary> 
    /// 根据当前日期 判断Access_Token 是否超期  如果超期返回新的Access_Token   否则返回之前的Access_Token 
    /// </summary> 
    /// <param name="datetime"></param> 
    /// <returns></returns> 
    public static string IsExistAccess_Token()
    {
        try
        {
            string Token = string.Empty;
            DateTime YouXRQ;
            //读取XML文件中的数据，并显示出来
            string filepath = HttpContext.Current.Request.MapPath("~/XMLFile.xml");
            StreamReader str = new StreamReader(filepath, System.Text.Encoding.UTF8);
            XmlDocument xml = new XmlDocument();
            xml.Load(str);
            str.Close();
            str.Dispose();
            Token = xml.SelectSingleNode("xml").SelectSingleNode("Access_Token").InnerText;
            YouXRQ = Convert.ToDateTime(xml.SelectSingleNode("xml").SelectSingleNode("Access_YouXRQ").InnerText);
            if (DateTime.Now > YouXRQ)
            {
                DateTime _youxrq = DateTime.Now;
                Access_token mode = GetAccess_Token();
                xml.SelectSingleNode("xml").SelectSingleNode("Access_Token").InnerText = mode.access_token;
                _youxrq = _youxrq.AddSeconds(Convert.ToInt32(mode.expires_in));
                xml.SelectSingleNode("xml").SelectSingleNode("Access_YouXRQ").InnerText = _youxrq.ToString();
                xml.Save(filepath);
                Token = mode.access_token;
            }
            return Token;
        }
        catch (Exception ex)
        {
            return "";//记录日志
        }
    }
}
 
public class Access_token
{
    public Access_token()
    { }
 
    public string access_token { get; set; }
    public string expires_in { get; set; }
}
 
public class JsonHelper
{
    /// <summary> 
    /// 生成Json格式 
    /// </summary> 
    /// <typeparam name="T"></typeparam> 
    /// <param name="obj"></param> 
    /// <returns></returns> 
    public static string GetJson<T>(T obj)
    {
        DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream stream = new MemoryStream())
        {
            json.WriteObject(stream, obj);
            string szJson = Encoding.UTF8.GetString(stream.ToArray()); return szJson;
        }
    }
    /// <summary> 
    /// 获取Json的Model 
    /// </summary> 
    /// <typeparam name="T"></typeparam> 
    /// <param name="szJson"></param> 
    /// <returns></returns> 
    public static T ParseFromJson<T>(string szJson)
    {
        T obj = Activator.CreateInstance<T>();
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            return (T)serializer.ReadObject(ms);
        }
    }
}
}