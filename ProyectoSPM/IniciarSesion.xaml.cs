using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSPM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IniciarSesion : ContentPage
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string psw = txtPsw.Text;
            Task<string> tarea = Gastos.FindUser(usuario, psw);
            tarea.Wait();
            string isValid = tarea.Result;
            if (isValid != null)
            {
                await Navigation.PushAsync(new Inicio(usuario));
            }
            else
            {
                await DisplayAlert("Error", "No existe el usuario", "Ok");
            }
        }
    }
}