using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Bluetooth1._0 {
    class Program {
        static Boolean stop = false;
        static void Main(string[] args) {
            //var o = BluetoothRadio.PrimaryRadio;
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices();
            BluetoothDeviceInfo device = null;
            foreach (BluetoothDeviceInfo d in devices) {
                if (d.DeviceName == "BLUETOOTH_DEVICE") {
                    device = d;
                    break;
                }
            }
            if (device != null) {
                Console.WriteLine(String.Format("Name:{0} Address:{1:C}", device.DeviceName, device.DeviceAddress));
                client.Connect(device.DeviceAddress, BluetoothService.SerialPort);
                Stream peerStream = client.GetStream();

                // Create storage for receiving data
                byte[] buffer = new byte[2000];

                // Read Data
                peerStream.Read(buffer, 0, 50);

                // Convert Data to String
                string data = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, 50);
                Console.WriteLine("Receiving data: " + data);

                int i = 0;
                while (true) {
                    Console.WriteLine("Writing: " + i.ToString());
                    byte[] dataBuffer = System.Text.ASCIIEncoding.ASCII.GetBytes(i.ToString());

                    peerStream.Write(dataBuffer, 0, dataBuffer.Length);
                    ++i;
                    if (i >= int.MaxValue) {
                        i = 0;
                    }
                    System.Threading.Thread.Sleep(500);
                }
                // Close network stream
                peerStream.Close();
            }
        }
        
    }

}
