using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecuperacionCinema.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            loginboton.Clicked += loginboton_Clicked;
		}

        private async void loginboton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar un Usuario", "Aceptar");
                userEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Debe Ingresar un Usuario", "Aceptar");
                passwordEntry.Focus();
                return;
            }

            loginActivity.IsRunning = true;
            loginboton.IsEnabled = false;
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");
            string url = string.Format("/api/Seguridad/{0}/{1}", userEntry.Text, passwordEntry.Text);
            var response = await cliente.GetAsync(url);
            var resultado = response.Content.ReadAsStringAsync().Result;
            loginboton.IsEnabled = true;
            loginActivity.IsRunning = false;

            if (string.IsNullOrEmpty(resultado) || resultado == "null")
            {
                await DisplayAlert("Error", "Usuario o clave no válidos", "Aceptar");
                passwordEntry.Text = string.Empty;
                passwordEntry.Focus();
                return;
            }

            await Navigation.PushModalAsync(new CarteleraPage());
        }
    }
}