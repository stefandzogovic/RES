using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Client
{
    public interface IClient
    {
        string Naziv_klijenta { get; set; }
        Model Model { get; set; }
        MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Trenutan_lobby { get; set; }
    }
}
