using Client;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Serverr
    {

        public MyTuple<Queue, Queue> Serverski_redovi { get; set; }
        public Dictionary<string, Clientt> klijenti { get; set; }
        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Klijentski_redovi_na_serveru { get; set; }
        public Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> lista_serverskih_redova { get; set; }
        public Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>> lista_klijentskih_redova { get; set; }
        public ClientFactory cf { get; set; }
        public ModelFactory mf { get; set; }
        public Repository repository { get; set; }

         public Serverr(ClientFactory cf, Repository repository)
         {
            Serverski_redovi = new MyTuple<Queue, Queue>(new Queue(), new Queue());
            Klijentski_redovi_na_serveru = new MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>();
            lista_klijentskih_redova = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
            lista_serverskih_redova = new Dictionary<string, MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>>>();
            klijenti = new Dictionary<string, Clientt>();
            mf = new ModelFactory();
            this.repository = repository;
            this.cf = cf;
         }


        public Clientt IzaberiClienta(IConsole console, Clientt klient)
        {
            console.WriteLine("/////LIST OF CLIENTS///////");
            foreach (string naziv in klijenti.Keys)
            {
                console.WriteLine(naziv);
            }

            string str;
            if (klijenti.ContainsKey(str = console.ReadLine()))
            {
                return klijenti[str];
            }
            else
            {
                return klient;
            }

        }


        public Clientt Kreiraj_klijenta(IConsole console)
        {
            console.WriteLine("Insert your name here: ");
            Clientt c = cf.ClientCreateNew(console.ReadLine()); 
            
            console.WriteLine(String.Format("\n_______Welcome: {0}_________", c.Naziv_klijenta));
            int broj_klijenata = klijenti.Count;
            c.Model = mf.CreateNewModel(++broj_klijenata);
            c.ModelId = broj_klijenata;
            klijenti.Add(c.Naziv_klijenta, c);
            


            return c;

        }

        public void IscitajIzBazeNaPocetku()
        {
            var clients = repository.Clients.ToList();
            var items = repository.Items.ToList();
            var positions = repository.Positions.ToList();
            var models = repository.Models.ToList();

            foreach(Clientt c in clients)
            {
                
                foreach(Model m in models)
                {
                    if(c.ModelId == m.Id)
                    {
                        c.Model = m;
                        break;
                    }
                }

                
                
                klijenti.Add(c.Naziv_klijenta, c);
            }
        }




    }
}
