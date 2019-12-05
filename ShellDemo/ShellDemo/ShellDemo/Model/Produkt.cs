using System;
using System.Collections.Generic;
using System.Text;

namespace ShellDemo.Model
{
    public class Produkt
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ProduktId { get; set; }
        public string Nazev { get; set; }
        public double Cena { get; set; }

        public Produkt()
        {

        }

        public Produkt(string nazev, double cena)
        {
            Nazev = nazev;
            Cena = cena;
        }
    }
}
