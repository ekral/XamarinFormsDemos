using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShellDemo.ViewModel
{
    class EditaceProduktuViewModel
    {
        public string Nazev { get; set; }
        public double Cena { get; set; }

        private Model.Produkt produkt;

        public EditaceProduktuViewModel(Model.Produkt produkt)
        {
            this.produkt = produkt;
            Nazev = produkt.Nazev;
            Cena = produkt.Cena;
        }

        public async Task Aktualizuj()
        {
            produkt.Nazev = Nazev;
            produkt.Cena = Cena;

            await App.Databaze.UpdateProductAsync(produkt);
        }
    }
}

