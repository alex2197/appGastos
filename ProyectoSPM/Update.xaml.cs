using Amazon.SecurityToken.Model;
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
    public partial class Update : ContentPage
    {
        Gastos gasto;
        public Update(Gastos xGasto)
        {
            gasto = xGasto;
            InitializeComponent();
            int monto = 0;
            int.TryParse(txtMonto.Text, out monto);

            txtTipo.Text = gasto.tipo;
            monto = gasto.monto;
            txtFecha.Text = gasto.fecha;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            int monto = 0;
            int.TryParse(txtMonto.Text, out monto);
            gasto.tipo = txtTipo.Text;
            gasto.monto = monto;
            gasto.fecha = txtFecha.Text;

            gasto.Save();

            await DisplayAlert("Actualizar", "Gasto Actualizado", "Ok");
        }
    }
}