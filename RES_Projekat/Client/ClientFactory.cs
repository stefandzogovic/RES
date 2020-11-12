using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientFactory
    {
        public Clientt ClientCreateNew(string str)
        {
            return new Clientt(str);
        }
    }
}
