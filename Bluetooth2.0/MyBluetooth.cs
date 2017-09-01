using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bluetooth {
    public class MyBluetooth {
        public BluetoothClient Blueclient = null;
        public BluetoothDeviceInfo[] Devices = null;
        public BluetoothRadio BuleRadio = BluetoothRadio.PrimaryRadio;
        public BluetoothDeviceInfo CurrentDevices = null;
        //public BluetoothService ser = null;

        public MyBluetooth() {
            Blueclient = new BluetoothClient();
        }

        public void DiscoverDevices() {
            BuleRadio.Mode = RadioMode.Connectable;
            Devices = Blueclient.DiscoverDevices();
        }
        public void Connect(BluetoothDeviceInfo Device) {
            try {
                CurrentDevices = Device;
                //Blueclient.SetPin(Device.DeviceAddress, null);
                //Blueclient.Connect(Device.DeviceAddress, BluetoothService.Handsfree);
            } catch (Exception ex) {

            }
        }

        public string Read() {
            try {
                Stream peerStream = Blueclient.GetStream();
                // Create storage for receiving data
                byte[] buffer = new byte[2000];
                // Read Data
                peerStream.Read(buffer, 0, 50);
                // Convert Data to String
                string data = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, 50);
                return data;
            } catch (Exception ex) {

                throw ex;
            }
        }

        public void Write(string str) {
            //try {
            //    //using (Stream peerStream = Blueclient.GetStream()) {
            //    Stream peerStream = Blueclient.GetStream();
            //        //byte[] dataBuffer = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            //        byte[] dataBuffer = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //        peerStream.Write(dataBuffer, 0, dataBuffer.Length);
            //        System.Threading.Thread.Sleep(500);
                
            //} catch (Exception ex) {
            //    throw ex;
            //}
            Console.WriteLine(String.Format("Name:{0} Address:{1:C}", CurrentDevices.DeviceName, CurrentDevices.DeviceAddress));
            if (Blueclient!=null) {
                Console.WriteLine("Close:--------------------------------------------------------------- ");
                Blueclient.Close();
                Thread.Sleep(100);
            }
            Blueclient = new BluetoothClient();
            var g = new Guid("00001101-0000-1000-8000-00805F9B34FB");
            //Blueclient.Connect(CurrentDevices.DeviceAddress, BluetoothService.Handsfree);
            try {
                Blueclient.Connect(CurrentDevices.DeviceAddress, g);
            } catch (Exception ex) {
                throw ex;
            }
            Stream peerStream = Blueclient.GetStream();
            peerStream.WriteTimeout = 500000;
            // Create storage for receiving data
            //byte[] buffer = new byte[2000];

            //// Read Data
            //peerStream.Read(buffer, 0, 50);

            //// Convert Data to String
            //string data = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, 50);
            //Console.WriteLine("Receiving data: " + data);
            int i = 0;
            while (true) {
                Console.WriteLine("Writing: " + i.ToString());
                byte[] dataBuffer = System.Text.ASCIIEncoding.ASCII.GetBytes(i.ToString());
                try {
                    peerStream.Write(dataBuffer, 0, dataBuffer.Length);
                } catch (Exception ex) {
                    peerStream.Close();
                    Console.WriteLine("Fail:----------- " + ex.Message);
                    Write("");
                    //throw ex;
                }
                ++i;
                if (i >= int.MaxValue) {
                    i = 0;
                }
                System.Threading.Thread.Sleep(100);
            }
            // Close network stream
        }

        public void StartService() {
            BluetoothListener listener = new BluetoothListener(BluetoothService.SerialPort);
            //listener.Server.
            listener.Start();
            Console.WriteLine("Service started!");
            //listener.
            BluetoothClient client = listener.AcceptBluetoothClient();
            Console.WriteLine("Got a request!");

            Stream peerStream = client.GetStream();

            string dataToSend = "Hello from service!";

            // Convert dataToSend into a byte array
            byte[] dataBuffer = System.Text.ASCIIEncoding.ASCII.GetBytes(dataToSend);

            // Output data to stream
            peerStream.Write(dataBuffer, 0, dataBuffer.Length);

            byte[] buffer = new byte[2000];
            while (true) {
                if (peerStream.CanRead) {
                    peerStream.Read(buffer, 0, 50);
                    string data = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, 50);
                    peerStream.Write(dataBuffer, 0, dataBuffer.Length);
                    peerStream.Flush();
                    Console.WriteLine("Receiving data: " + data);
                }
            }
        }

    }
}
