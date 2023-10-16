using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace usb
{
    internal class Program
    {
        

        static void Main()
    {
        
        ManagementEventWatcher watcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 or EventType = 3"));
        watcher.EventArrived += (sender, e) =>
        {
            string eventType = e.NewEvent.Properties["EventType"].Value.ToString();
            

            if (eventType == "2")
            {
                Console.WriteLine("USB Connected");
            }
            else if (eventType == "3")
            {
                Console.WriteLine("USB Disconnected");
            }
        };

        // Start of event tracking
         watcher.Start();

        Console.WriteLine("Press Enter for close program.");
        Console.ReadLine();

        // Stop tracking events on program termination
          watcher.Stop();
        }
    }
}
