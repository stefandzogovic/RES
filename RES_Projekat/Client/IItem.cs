using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IItem
    {
        string Naziv { get; set; }
        int Kolicina { get; set; }
        bool Aktiviran { get; set; }
        int Razorna_moc { get; set; }
        string ToString();
    }
}

