using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Pomocne_funkcijeCreate : IPomocne_funkcijeCreate
    {
        public MyTupleFactory mtf { get; set; }
        public QueueFactory qf { get; set; }

        public Pomocne_funkcijeCreate(MyTupleFactory mtf, QueueFactory qf)
        {
            this.qf = qf;
            this.mtf = mtf;
        }

        public bool Jedinstvenost(string str, Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> lista_klijentskih_redova)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Parametar ne sme biti null.");
            }

            if (str == "")
            {
                throw new ArgumentException("Parametar mora sadrzati karaktere.");
            }

            if(!lista_klijentskih_redova.ContainsKey(str))
            {
                return false;
            }
            else

            return true;
        }

        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> CreateClientQueues(string str)
        {
            MyTuple<string, Queue> tupleA = mtf.CreateNewMyTuple(str + "A", qf);
            MyTuple<string, Queue> tupleB = mtf.CreateNewMyTuple(str + "B", qf);

            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> tuple = mtf.CreateNewMyTuple1(tupleA, tupleB);

            return tuple;

        }

        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> CreateServerQueuePair(Queue q, Queue q1)
        {
            string naziv_reda = q.Dequeue().ToString();
            string[] x = naziv_reda.Split('(');
            string queue = x[1].TrimEnd(')');
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Client_server_queues = mtf.CreateNewMyTuple1(mtf.CreateNewMyTuple("Server" + queue + "A", qf), mtf.CreateNewMyTuple("Server" + queue + "B", qf));
            Enqueue(q1, "Uspesno kreirani redovi na serverskoj strani: " + Client_server_queues.Item1.Item1 + " & " + Client_server_queues.Item2.Item1); // ovo mozda ne valja enqueue umesto q1.enqueue

            return Client_server_queues;

        }


        public bool Enqueue(Queue q, string str)
        {
            if (q.Count == 0)
            {
                q.Enqueue(str);
                return true;
            }
            else return false;
        }

        public object Dequeue(Queue q)
        {
            if (q.Count != 0)
            {
                return q.Dequeue();
            }

            else
                return "Queue is empty";
        }
    }
}
