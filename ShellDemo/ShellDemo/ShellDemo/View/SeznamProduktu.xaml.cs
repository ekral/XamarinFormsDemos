using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeznamProduktu : ContentPage
    {
        private ViewModel.ProduktyViewModel viewModel;

        public SeznamProduktu()
        {
            BindingContext = viewModel = new ViewModel.ProduktyViewModel();

            InitializeComponent();
        }

        private async void ToolbarItemNovy_Odstran_Clicked(object sender, EventArgs e)
        {
            bool smazat = await DisplayAlert("Smazaní produktu", "Opravdu chceš smazat vybraný produkt?", "Smazat", "Zrušit");
            
            if (smazat)
            {
                await viewModel.OdstranVybranyProdukt();
                await viewModel.NactiProdukty();
            }
        }

        private async void ToolbarItemNovy_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new View.NovyProdukt()));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (viewModel.ZvolenyProdukt != null)
            {
                EditaceProduktu page = new View.EditaceProduktu(viewModel.ZvolenyProdukt);
                await Shell.Current.Navigation.PushModalAsync(new NavigationPage(page));
            }
        }
        protected async override void OnAppearing()
        {
            await viewModel.NactiProdukty();
        }

    }
}