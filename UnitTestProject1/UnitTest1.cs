using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Base;
using System.Text;
using System.Reflection;
using Unity.IO;
using System.Diagnostics;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var o = new Dictionary<Object, Object>();
            o = o.AddTry("1", "2");
            o = o.AddTry(3, 4);
            o = o.AddTry(new { name = 5, nick = "505" }, new { value = 6 });
            var str = o.ToStringFormat(":", ",");
        }

        [TestMethod]
        public void TestX() {
            Debug.WriteLine("开始时间:" + DateTime.Now);
            for (var i = 1; i < 100000; i++) {
                if (i / 10 == 0) {
                    Debug.WriteLine(i);
                }
                x(i);
            }
            Debug.WriteLine("结束时间:" + DateTime.Now );
            Console.ReadKey();
        }

        public void x(int ID) {
            try {
                String path = Assembly.GetExecutingAssembly().Location;
                path = path.Substring(0, path.LastIndexOf('\\')) + "\\TempOrder.txt";//删除文件名
                if (!ExIO.Exists(path)) {
                    ExIO.CreateFile(path);
                }
                String str = ExIO.Read(path);
                if (str.Contains(ID + ",")) {
                    return;
                }
                str += ID + ",";
                if (str.Length > 20000) {
                    str = str.Substring(10000);
                    str = str.TrimStart(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                    str = str.TrimStart(',');
                }
                if (!ExIO.Write(path, str)) {
                    return;
                }
            } catch (Exception ex) {
                throw;
            }
        }
    }
}
