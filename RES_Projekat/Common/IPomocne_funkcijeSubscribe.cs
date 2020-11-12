﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IPomocne_funkcijeSubscribe
    {
        string SaveToXml<T>(T obj);
        T ReadFromXml<T>(string str);
        bool Enqueue(Queue q, string str);
        object Dequeue(Queue q);
        MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Izaberi(Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> dict, string naz, IConsole console);


    }
}
