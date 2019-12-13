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
    public partial class EditaceProduktu : ContentPage
    {
        ViewModel.EditaceProduktuViewModel viewModel;
        public EditaceProduktu(Model.Produkt zvolenyProdukt)
        {
            BindingContext = viewModel = new ViewModel.EditaceProduktuViewModel(zvolenyProdukt);
            InitializeComponent();
        }

        private async void ToolbarItemUloz_Clicked(object sender, EventArgs e)
        {
            await viewModel.Aktualizuj();

            await Shell.Current.Navigation.PopModalAsync();
        }

        private async void ToolbarItemZrus_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}