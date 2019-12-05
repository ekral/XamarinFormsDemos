using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellDemo.ViewModel
{
    class NovyProduktViewModel : ViewModelBase
    {
        public string Nazev { get; set; }
        public double Cena { get; set; }

        public NovyProduktViewModel()
        {
        }

        public async Task Uloz()
        {
            Model.Produkt produkt = new Model.Produkt(Nazev, Cena);
            int pocetZaznamu = await App.Databaze.InsertProductAsync(produkt);
        }
    }
}
