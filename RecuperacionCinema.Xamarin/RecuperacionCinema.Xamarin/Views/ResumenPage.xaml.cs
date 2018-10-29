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
	public partial class ResumenPage : ContentPage
	{
		public ResumenPage (Funciones function, Pelicula cartelera)
		{
			InitializeComponent ();
		}
	}
}