﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IPomocne_funkcijeCreate
    {
        bool Jedinstvenost(string str, Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> lista_klijentskih_redova);
        MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> CreateClientQueues(string str);
        MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> CreateServerQueuePair(Queue q, Queue q1);
        bool Enqueue(Queue q, string str);
        object Dequeue(Queue q);

    }
}
