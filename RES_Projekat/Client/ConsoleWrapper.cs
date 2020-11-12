using Common;
using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ConsoleWrapper : IConsole
    {
        public virtual void Write(string message)
        {
            Console.Write(message);
        }

        public virtual ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }


        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }

    }
}
