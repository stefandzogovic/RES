using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public bool Aktiviran { get; set; }
        public int Razorna_moc { get; set; }
        [XmlIgnore]
        public Model Model { get; set; }
        [XmlIgnore]
        public int? ModelId { get; set; }

        public Item()
        {

        }

        public Item(string naz, int kol, bool akt, int raz)
        {
            if (naz == null)
            {
                throw new ArgumentNullException("Naziv ne sme biti null.");
            }

            if (naz == "")
            {
                throw new ArgumentException("Naziv mora sadrzati karaktere.");
            }

            if (kol <= 0)
            {
                throw new ArgumentException("Kolicina ne sme biti negativna ili 0.");
            }

            if (raz <= 0)
            {
                throw new ArgumentException("Razorna moc ne sme biti negativna ili 0.");
            }




            Naziv = naz;
            Kolicina = kol;
            Aktiviran = akt;
            Razorna_moc = raz;

            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            if (Aktiviran)
            {
                return "----Item-----\nNaziv: " + Naziv + "\nKolicina: " + Kolicina + "\nAktiviran je.\nRazorna moc: " + Razorna_moc + " J";
            }
            else
                return "----Item-----\nNaziv: " + Naziv + "\nKolicina: " + Kolicina.ToString() + "\nNije aktiviran.\nRazorna moc: " + Razorna_moc.ToString() + " J";
        }
    }
}