using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static RecuperacionCinema.Xamarin.Models.Cinema;

namespace RecuperacionCinema.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionPage : ContentPage
	{
        private Pelicula cinemark;

        public FuncionPage (Pelicula cartelera)
		{
			InitializeComponent ();
            BindingContext = cartelera;
            SeleccionFuncion.ItemsSource = cartelera.Funciones;
            cinemark = cartelera;
        }

        private async void SeleccionFuncion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var function = e.SelectedItem as Funciones;
            await Navigation.PushAsync(new ResumenPage(function, cinemark));
        }
    }
}