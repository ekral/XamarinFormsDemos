using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ShellDemo.ViewModel
{
    class ProduktyViewModel : ViewModelBase
    {
        public ObservableCollection<Model.Produkt> Produkty { get; set; }
        public Model.Produkt ZvolenyProdukt { get; set; }

        public ProduktyViewModel()
        {
            Produkty = new ObservableCollection<Model.Produkt>();
        }

        public async Task NactiProdukty()
        {
            Produkty.Clear();

            foreach (Model.Produkt produkt in await App.Databaze.GetAllProductsAsync())
            {
                Produkty.Add(produkt);
            }
        }

        public async Task OdstranVybranyProdukt()
        {
            if (ZvolenyProdukt != null)
            {
                await App.Databaze.DeleteProductAsync(ZvolenyProdukt.ProduktId);
            }
        }
    }
}
