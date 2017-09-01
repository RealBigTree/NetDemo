using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Base;
using System.Text;

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

    }
}
