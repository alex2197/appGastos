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
    public partial class Save : ContentPage
    {
        Random numeroAleatorio = new Random();
        public Save()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            int monto = 0;
            int.TryParse(txtMonto.Text, out monto);
            Gastos gastos = new Gastos();
            gastos.id = GetNewId();
            gastos.tipo = txtTipo.Text;
            gastos.monto = monto;
            gastos.fecha = txtFecha.Text;


            gastos.Save();

            await DisplayAlert("Guardar", "Gasto Guardado", "Ok");
        }

        private int GetNewId()
        {
            return numeroAleatorio.Next();
        }
    }
}