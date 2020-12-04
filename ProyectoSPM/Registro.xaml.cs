using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSPM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        Random numeroAleatorio = new Random();
        public Registro()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Gastos gasto = new Gastos();
            gasto.id = GetNewId();
            gasto.nombre = txtName.Text;
            gasto.usuario = txtUser.Text;
            gasto.psw = txtPsw.Text;

            gasto.Save();
            await DisplayAlert("Registro", "Usuario registrado", "Ok");
        }

        private int GetNewId()
        {
            return numeroAleatorio.Next();
        }
    }
}