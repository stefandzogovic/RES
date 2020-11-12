using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyTuple<TypeParameter1, TypeParameter2>
    {
        public TypeParameter1 Item1 { get; set; }
        public TypeParameter2 Item2 { get; set; }

        public MyTuple()
        {

        }
        public MyTuple(TypeParameter1 item1, TypeParameter2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}
