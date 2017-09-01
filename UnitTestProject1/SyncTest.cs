using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1 {
    [TestClass]
    public class SyncTest {
        public async void Async2() {
            string x = "xxx";
            var o = Task.Run(() => { Thread.Sleep(500); x += x; Debug.WriteLine(x); });
            Thread.Sleep(100);
            Debug.WriteLine(x);
            await o;
            Debug.WriteLine(x+=x);

        }
        [TestMethod]
        public void aaa() {
            Async1();
            Async2();
            Debug.WriteLine("aaa"); 
            Console.ReadLine();
        }

        public async void Async1() {
            string x = "bbb";
            await Task.Run(() => { Thread.Sleep(300); x += x; Debug.WriteLine(x); });
            Thread.Sleep(100);
            Debug.WriteLine("ccc");

        }
    }
}
