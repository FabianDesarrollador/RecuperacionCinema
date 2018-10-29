using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static RecuperacionCinema.Xamarin.Models.Cinema;

namespace RecuperacionCinema.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarteleraPage : ContentPage
    {
        public CarteleraPage()
        {
            InitializeComponent();
            CargarPelis();
        }

        private async void CargarPelis()
        {
            HttpClient cines = new HttpClient();

            cines.BaseAddress = new Uri("http://misapis.azurewebsites.net");
            var request = await cines.GetAsync("/api/Cartelera");

            if (request.IsSuccessStatusCode)
            {
                var responseJSON = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<Pelicula>>(responseJSON);
                liCarteleras.ItemsSource = respuesta;

            }
        }

        private async void PeliSeleccion(object sender, SelectedItemChangedEventArgs e)
        {
            var cartelera = e.SelectedItem as Pelicula;
            await Navigation.PushAsync(new FuncionPage(cartelera));


        }
    }
}