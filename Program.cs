//*****************************************************************************
//** Network Connections                                                     **
//** A simple project to show available network connections.           -Dan  **
//*****************************************************************************

using System;
using System.Net.NetworkInformation;

namespace NetworkConnections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Available Network Connections:");
            Console.WriteLine("-------------------------------");

            // Get all network interfaces (network adapters) on the machine
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                Console.WriteLine("Name: " + network.Name);
                Console.WriteLine("Description: " + network.Description);
                Console.WriteLine("Status: " + network.OperationalStatus);

                // Get the IP properties of the network interface
                IPInterfaceProperties ipProperties = network.GetIPProperties();

                // Display unicast addresses (IP addresses)
                foreach (UnicastIPAddressInformation ip in ipProperties.UnicastAddresses)
                {
                    Console.WriteLine("IP Address: " + ip.Address);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}