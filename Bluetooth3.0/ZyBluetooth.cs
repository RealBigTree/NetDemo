using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bluetooth3._0 {
    public class ZyBluetooth {
        BluetoothRadio radio = null;//蓝牙适配器 
        string sendFileName = null;//发送文件名 
        BluetoothAddress sendAddress = null;//发送目的地址 
        ObexListener listener = null;//监听器 
        string recDir = null;//接受文件存放目录 
        Thread listenThread, sendThread;//发送/接收线程

        public ZyBluetooth() {
            radio = BluetoothRadio.PrimaryRadio;//获取当前PC的蓝牙适配器 
            recDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }


    }
}
