using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestProject1 {
    [TestClass]
    public class DynamicTest {
        [TestMethod]
        public void Run() {
            try {
                dynamic a = new System.Dynamic.ExpandoObject();
                a.a = 1;
                a.b = 2;
                a.c = new Action(delegate() {
                    Debug.WriteLine("-------------- - ");
                });
                a.d = new Func<string>(delegate() {
                    return "xxxxxxxxxxxxxxxxxxxxxxxxxxx";
                });
            } catch (Exception ex) {
                
                throw ex;
            }
            //Debug.ReadKey();
        }
    }
}
