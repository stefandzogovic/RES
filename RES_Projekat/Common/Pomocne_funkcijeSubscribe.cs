using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Common
{
    public class Pomocne_funkcijeSubscribe : IPomocne_funkcijeSubscribe
    {

        public MyTupleFactory mtf { get; set; }
        public QueueFactory qf { get; set; }
        

        public Pomocne_funkcijeSubscribe(MyTupleFactory mtf, QueueFactory qf)
        {
            this.qf = qf;
            this.mtf = mtf;
        }
        public string SaveToXml<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                Console.WriteLine(stringWriter.ToString());
                return stringWriter.ToString();
            }
        }

        public T ReadFromXml<T>(string str)
        {
            var serializer = new XmlSerializer(typeof(T));
            T model;

            using (TextReader reader = new StringReader(str))
            {
                model = (T)serializer.Deserialize(reader);
            }
            return model;

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

        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Izaberi(Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict, string naziv_trenutnog_lobbyja, IConsole console)
        {
            MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> tuple = mtf.CreateNewMyTuple1(mtf.CreateNewMyTuple("", qf), mtf.CreateNewMyTuple("", qf));

            foreach (string str in dict.Keys)
            {
                console.WriteLine(str);
            }
            if (dict.Count != 0)
            {
                while (true)
                {
                    console.WriteLine("Choose lobby name: ");
                    string x = console.ReadLine();
                    if (dict.ContainsKey(x) && x != naziv_trenutnog_lobbyja)
                    {
                        tuple = dict[x];
                        return tuple;
                    }
                    else
                    {
                        console.WriteLine("Pogresan unos!");
                    }
                }
            }
            else
                return null;
        }


    }
}
