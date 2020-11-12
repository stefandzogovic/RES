using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Pomocne_funkcijeUpdate
{
    public interface IPomocne_funkcijeUpdate
    {
        bool Enqueue(Queue q, object str);
        object Dequeue(Queue q);
        Item IzmeniItem(List<Item> lista, IConsole console);
        Item DodajItem(IConsole console);
    }
}
