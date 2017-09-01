using Bluetooth;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bluetooth2._0 {
    class Program {
        static void Main(string[] args) {
            MyBluetooth mb = new MyBluetooth();
            Console.WriteLine("本机设备名称:" + mb.BuleRadio.Name + ",地址:" + mb.BuleRadio.LocalAddress);
            while (true) {
                var x = Console.ReadLine();
                if(x=="d"){
                    mb.DiscoverDevices();
                    int i = 0;
                    foreach(var o in mb.Devices){
                        Console.WriteLine("序号:" + i + ",设备名:" + o.DeviceName+ ",地址:" + o.DeviceAddress);
                        i++;
                    }
                } else if (x.StartsWith("c")) {
                    var para = x.Split(' ')[1];
                    mb.Connect(mb.Devices[int.Parse(para)]);
                    Console.WriteLine("连接成功! 设备名:" + mb.CurrentDevices.DeviceName + ",地址:" + mb.CurrentDevices.DeviceAddress);
                } else if (x.StartsWith("r")) {
                    Console.WriteLine(mb.Read());
                } else if (x.StartsWith("w")) {
                    string str="Hello World ! ";
                    mb.Write(str);
                    Console.WriteLine("写入数据:" + str);
                } else if (x.StartsWith("q")) {
                    MyBluetoothService ms = new MyBluetoothService();
                } else if (x.StartsWith("s")) {
                    //MyBluetoothService ms = new MyBluetoothService();
                    Console.WriteLine("启动服务------------------------");
                    mb.StartService();
                    Console.WriteLine("启动服务++++++++++++++");
                }
            }
        }
    }
}
