using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("Model")]
    public class Model
    {
        public int Id { get; set; }
    
        public List<Item> Items { get; set; }
        [NotMapped]
        public List<Clientt> Clients { get; set;}
        public List<Position> Positions { get; set;}

        
        public Model()
        {
            Items = new List<Item>();
            Clients = new List<Clientt>();
            Positions = new List<Position>();
        }

        public Model(int Id)
        {
            this.Id = Id;
            Items = new List<Item>();
            Clients = new List<Clientt>();
            Positions = new List<Position>();
        }


    }
}
