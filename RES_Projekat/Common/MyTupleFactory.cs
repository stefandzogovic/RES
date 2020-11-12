using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyTupleFactory
    {
        public MyTuple<string, Queue> CreateNewMyTuple(string str, QueueFactory qf)
        {
            return new MyTuple<string, Queue>(str, qf.CrateNewQueue());
        }

        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> CreateNewMyTuple1(MyTuple<string, Queue> tuple1, MyTuple<string, Queue> tuple2)
        {
            return new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>(tuple1, tuple2);
        }
    }
}
