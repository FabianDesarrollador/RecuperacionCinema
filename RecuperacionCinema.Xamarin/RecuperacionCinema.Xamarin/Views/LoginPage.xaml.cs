using Newtonsoft.Json;
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
            var pass = new
            {
                Usuario = "Admin",
                Password = "CinemaAdmin"
            };
            var user = JsonConvert.SerializeObject(cliente);
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");
            var id = new StringContent(user, Encoding.UTF8, "application/json");
            var response = cliente.PostAsync("/api/Seguridad", id).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync.Result;
                var respond = JsonConvert.DeserializeObject<LoginPage>(json);
            }
            
            
            loginboton.IsEnabled = true;
            loginActivity.IsRunning = false;

            if (response.IsSuccessStatusCode (json) || resultado == "null")
            {
                await DisplayAlert("Error", "Usuario o clave no válidos", "Aceptar");
                passwordEntry.Text = string.Empty;
                passwordEntry.Focus();
                return;
            }

            await Navigation.PushAsync(new CarteleraPage());
        }
    }
}