using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common;
using Server;

namespace Client
{
    public class Clientt : IClient
    {
        public int Id { get; set; }
        [XmlIgnore]
        public Model Model { get; set; }
        [XmlIgnore]
        public int? ModelId { get; set; }
        public string Naziv_klijenta { get; set; }
        [XmlIgnore]
        public MyTuple<MyTuple<string, Queue>, MyTuple<string, Queue>> Trenutan_lobby { get; set; }

        public string Naziv_trenutnog_lobbyja {get; set;}

        public Clientt()
        {

        }

        public Clientt(string naziv)
        {
            Trenutan_lobby = null;
            Naziv_klijenta = naziv;
        }
     

    }
}
