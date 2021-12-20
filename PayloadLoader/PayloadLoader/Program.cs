using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PayloadLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string namefile = args[0];
                byte[] byteBuffer = File.ReadAllBytes(namefile);
                string hex = BitConverter.ToString(byteBuffer);
                string[] newint = hex.Split('-');

                string newpayload = "var payload = [";
                Console.WriteLine("wait...");
                foreach (string value in newint)
                { int modint = Convert.ToInt32("0x" + value, 16); newpayload += (modint + ","); }
                newpayload = newpayload.Substring(0, newpayload.Length - 1) + "];";
                Console.WriteLine(newpayload);
                File.WriteAllText("payload.js", newpayload);
                
            }
        }
    }
}
