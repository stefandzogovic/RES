using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Pomocne_funkcijeUpdate
{
    public class Pomocne_funkcijeUpdate : IPomocne_funkcijeUpdate
    {
        public bool Enqueue(Queue q, object str)
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

        public Item IzmeniItem(List<Item> lista, IConsole console)
        {

            foreach (Item i in lista)
            {
                if (i.Naziv == console.ReadLine())
                {
                    console.WriteLine("Unesi nov naziv: ");
                    i.Naziv = console.ReadLine();
                    console.WriteLine("Unesi novu kolicinu: ");
                    i.Kolicina = Int32.Parse(console.ReadLine());
                    console.WriteLine("Unesi da li je aktiviran ili nije: Y/N");
                    if (console.ReadKey().Key == ConsoleKey.Y)
                    {
                        i.Aktiviran = true;
                    }
                    else if (console.ReadKey().Key == ConsoleKey.N)
                    {
                        i.Aktiviran = false;
                    }
                    console.WriteLine("Unesi moc: ");
                    i.Razorna_moc = Int32.Parse(console.ReadLine());

                    return i;

                }

                else
                {
                    console.WriteLine("Ne postoji taj item!");
                    return null;
                }
            }

            return null;

        }

        public Item DodajItem(IConsole console)
        {
            Item i = new Item();
            console.WriteLine("Unesi nov naziv: ");
            i.Naziv = console.ReadLine();
            console.WriteLine("Unesi novu kolicinu: ");
            i.Kolicina = Int32.Parse(console.ReadLine());
            console.WriteLine("Unesi da li je aktiviran ili nije: Y/N");
            if (console.ReadKey().Key == ConsoleKey.Y)
            {
                i.Aktiviran = true;
            }
            else if (console.ReadKey().Key == ConsoleKey.N)
            {
                i.Aktiviran = false;
            }
            console.WriteLine("Unesi moc: ");
            i.Razorna_moc = Int32.Parse(console.ReadLine());

            return i;
        }

    }
}
