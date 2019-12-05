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
    public partial class NovyProdukt : ContentPage
    {
        private ViewModel.NovyProduktViewModel viewModel;

        public NovyProdukt()
        {
            BindingContext = viewModel = new ViewModel.NovyProduktViewModel();

            InitializeComponent();
        }

        private async void ToolbarItemUloz_Clicked(object sender, EventArgs e)
        {
            await viewModel.Uloz();

            await Shell.Current.Navigation.PopModalAsync();
        }

        private async void ToolbarItemZrus_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}