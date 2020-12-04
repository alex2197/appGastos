using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSPM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public ObservableCollection<Gastos> Gasto { get; private set; }
        public Inicio()
        {
            InitializeComponent();
            Gasto = new ObservableCollection<Gastos>();
            grData.ItemsSource = Gasto;
            Gasto.Clear();
            Task<List<Gastos>> tarea = Gastos.LoadAll();
            foreach (Gastos item in tarea.Result)
            {
                Gasto.Add(item);
            }
        }


        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Save());
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            object seleccionado = grData.SelectedItem;
            if (seleccionado == null)
            {
                await DisplayAlert("Actualizar", "Seleccione un registro", "Ok");
            }
            else
            {
                Gastos gasto = (Gastos)seleccionado;
                await Navigation.PushAsync(new Update(gasto));
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            object seleccionado = grData.SelectedItem;
            if (seleccionado == null)
            {
                await DisplayAlert("Eliminar", "Seleccione un registro", "Ok");
            }
            else
            {
                Gastos gasto = (Gastos)seleccionado;
                gasto.Delete();
                await DisplayAlert("Eliminar", "Gasto eliminado", "Ok");
            }
        }

        private async void btnActualizarTabla_Clicked(object sender, EventArgs e)
        {
            Gasto.Clear();
            Task<List<Gastos>> tarea = Gastos.LoadAll();
            foreach (Gastos item in tarea.Result)
            {
                Gasto.Add(item);
            }
        }
    }
}