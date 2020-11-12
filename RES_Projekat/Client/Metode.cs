
using Client.Pomocne_funkcijeUpdate;
using Common;
using Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client
{
    public class Metode : IMetode
    {
        public Serverr server { get; set; }
        public IConsole console { get; set; }

        public Metode(Serverr server, IConsole console)
        {
            this.server = server;
            this.console = console;
        }

        public Clientt Subscribe(IPomocne_funkcijeSubscribe pf, string trenutan_lobby, int id, Model m, string imeK, bool resubscribe)
        {

            
            Clientt c1 = server.cf.ClientCreateNew(imeK);
            if(resubscribe)
            {
                c1.Model = m;
                c1.Naziv_trenutnog_lobbyja = trenutan_lobby;
                foreach(Clientt client in server.klijenti.Values)
                {
                    if(client.Naziv_trenutnog_lobbyja == c1.Naziv_trenutnog_lobbyja)
                    {
                        client.Model.Clients.RemoveAll(p => p.Naziv_klijenta == c1.Naziv_klijenta);
                        c1.Model.Clients.RemoveAll(p => p.Naziv_klijenta == client.Naziv_klijenta);
                    }
                }
            }

            c1.Trenutan_lobby = pf.Izaberi(server.lista_klijentskih_redova, trenutan_lobby, console);
            if(c1.Trenutan_lobby == null)
            {
                console.WriteLine("Pogresan izbor");
                return null;
            }
            else
            {
                c1.Naziv_trenutnog_lobbyja = c1.Trenutan_lobby.Item1.Item1.TrimEnd('A');

            }




            string asdf = (pf.SaveToXml<Model>(m));
            pf.Enqueue(server.Serverski_redovi.Item1, asdf);

            c1.Model = pf.ReadFromXml<Model>((string)pf.Dequeue(server.Serverski_redovi.Item1));
            c1.Id = id;

            foreach (Clientt client in server.klijenti.Values)
            {
                if(client.Naziv_trenutnog_lobbyja == c1.Naziv_trenutnog_lobbyja && client.Naziv_klijenta != c1.Naziv_klijenta && !c1.Model.Clients.Contains(client))
                {
                    client.Model.Clients.Add(c1);
                    c1.Model.Clients.Add(client);
                }
            }

            pf.Enqueue(server.Serverski_redovi.Item2, ("Client: " + c1.Naziv_klijenta + " se uspesno subscribovao na red: " + c1.Trenutan_lobby.Item1.Item1.TrimEnd('A')));

            console.WriteLine(pf.Dequeue(server.Serverski_redovi.Item2).ToString());

            server.klijenti[c1.Naziv_klijenta] = c1;

            return c1;
        }

        public bool Create(IPomocne_funkcijeCreate pf, Clientt c)
        {

            console.WriteLine("Unesi ime reda");
            string str = console.ReadLine();

            if (!pf.Jedinstvenost(str, server.lista_klijentskih_redova))
            {
                // stavi u nov


                //resubscribe
                foreach (Clientt client in server.klijenti.Values)
                {
                    if (client.Naziv_trenutnog_lobbyja == c.Naziv_trenutnog_lobbyja)
                    {
                        client.Model.Clients.RemoveAll(p => p.Naziv_klijenta == c.Naziv_klijenta);
                        c.Model.Clients.RemoveAll(p => p.Naziv_klijenta == client.Naziv_klijenta);
                    }
                }

                c.Trenutan_lobby = pf.CreateClientQueues(str);
                c.Naziv_trenutnog_lobbyja = c.Trenutan_lobby.Item1.Item1.Trim('A');
                console.WriteLine("Uspesno kreiran redovi na klijentskoj strani: " + c.Trenutan_lobby.Item1.Item1 + " & " + c.Trenutan_lobby.Item2.Item1);
                server.lista_klijentskih_redova.Add(str, c.Trenutan_lobby);

                pf.Enqueue(server.Serverski_redovi.Item1, "\nClient: " + c.Naziv_klijenta + " sent: Create Queue (" + str + ")");

                server.Klijentski_redovi_na_serveru = pf.CreateServerQueuePair(server.Serverski_redovi.Item1, server.Serverski_redovi.Item2);

                console.WriteLine(pf.Dequeue(server.Serverski_redovi.Item2).ToString());

                server.lista_serverskih_redova.Add(str, server.Klijentski_redovi_na_serveru);


                return true;

            }
            else
            {
                console.WriteLine("Uneo si vec postojeci lobby.");
                return false;
            }
        }

        public bool Update(IPomocne_funkcijeUpdate pfu, Clientt c)
        {
            Item item = new Item();
            string str = "";
            bool bul = true;

            while (true)
            {
                console.WriteLine("\n\n1.Izmeni Item\n2.Dodaj nov Item\n");
                var key = console.ReadKey().Key;
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    foreach (Item i in c.Model.Items)
                    {
                        Console.WriteLine(i.Naziv);
                    }


                    item = pfu.IzmeniItem(c.Model.Items, console);
                    if (item != null)
                    {
                        server.repository.SaveChanges();
                        break;
                    }

                }
                else if(key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    item = pfu.DodajItem(console);
                    pfu.Enqueue(c.Trenutan_lobby.Item1.Item2, item);
                    foreach(var pair in server.lista_serverskih_redova)
                    {
                        if(pair.Key ==  "Server" + c.Naziv_trenutnog_lobbyja)
                        {
                            server.Klijentski_redovi_na_serveru = pair.Value;
                        }
                    }

                    pfu.Enqueue(server.Klijentski_redovi_na_serveru.Item1.Item2, pfu.Dequeue(c.Trenutan_lobby.Item1.Item2));


                    console.WriteLine(server.Klijentski_redovi_na_serveru.Item1.Item2.Dequeue().ToString());

                    foreach (Item it in server.repository.Items)
                    {
                        if(it.Naziv == item.Naziv)
                        {
                            str = "Taj item vec postoji!";
                            bul = false;
                        }
                    }

                    if (bul)
                    {
                        str = "Change from Client" + c.Naziv_klijenta + "   //// " + item.ToString();
                        c.Model.Items.Add(item);
                        server.repository.SaveChanges();
                    }


                    server.Klijentski_redovi_na_serveru.Item2.Item2.Enqueue(str);
                    server.Klijentski_redovi_na_serveru.Item2.Item2.Dequeue();

                    foreach(Clientt client in server.klijenti.Values)
                    {
                        if(client.Naziv_trenutnog_lobbyja == c.Naziv_trenutnog_lobbyja)
                        {
                            client.Trenutan_lobby.Item2.Item2.Enqueue(client.Naziv_klijenta + "Recieved " + str);
                            console.WriteLine(client.Trenutan_lobby.Item2.Item2.Dequeue().ToString());
                        }
                    }

                    break;

                }
                else
                {

                }
            }

            return true;
        }

        public void ShowClientData(Clientt c)
        {
            foreach(Item i in c.Model.Items)
            {
                console.WriteLine(i.ToString());
            }

            foreach(Position p in c.Model.Positions)
            {
                console.WriteLine(p.ToString());
            }

            foreach(Clientt client in c.Model.Clients)
            {
                console.WriteLine(client.Naziv_klijenta);
            }
        }

        public void ShowOtherClientsData(List<Clientt> klijenti)
        {
            //To be continued...
        }
    }
}
