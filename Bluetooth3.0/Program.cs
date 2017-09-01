using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluetooth3._0 {
    class Program {
        static void Main(string[] args) {
            BluetoothRadio bluetoothRadio = BluetoothRadio.PrimaryRadio;
            if (bluetoothRadio == null) {
                Console.WriteLine("没有找到本机蓝牙设备!");
            } else {
                Console.WriteLine("ClassOfDevice: " + bluetoothRadio.ClassOfDevice);
                Console.WriteLine("HardwareStatus: " + bluetoothRadio.HardwareStatus);
                Console.WriteLine("HciRevision: " + bluetoothRadio.HciRevision);
                Console.WriteLine("HciVersion: " + bluetoothRadio.HciVersion);
                Console.WriteLine("LmpSubversion: " + bluetoothRadio.LmpSubversion);
                Console.WriteLine("LmpVersion: " + bluetoothRadio.LmpVersion);
                Console.WriteLine("LocalAddress: " + bluetoothRadio.LocalAddress);
                Console.WriteLine("Manufacturer: " + bluetoothRadio.Manufacturer);
                Console.WriteLine("Mode: " + bluetoothRadio.Mode);
                Console.WriteLine("Name: " + bluetoothRadio.Name);
                Console.WriteLine("Remote:" + bluetoothRadio.Remote);
                Console.WriteLine("SoftwareManufacturer: " + bluetoothRadio.SoftwareManufacturer);
                Console.WriteLine("StackFactory: " + bluetoothRadio.StackFactory);
            }
            Console.ReadKey();
        } 

    }
}
