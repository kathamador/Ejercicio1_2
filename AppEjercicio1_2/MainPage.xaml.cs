using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppEjercicio1_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            try
            {
                await this.Navigation.PushAsync(
                    new Resultado(
                        $" Nombres: {nombres.Text} \n\n Apellidos: {apellidos.Text} \n\n Edad: {edad.Text} años \n\n Correo: {correo.Text}")
                );
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
           
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(nombres.Text) && string.IsNullOrWhiteSpace(apellidos.Text) && string.IsNullOrWhiteSpace(edad.Text) && string.IsNullOrWhiteSpace(correo.Text))
            {
                DisplayAlert("Error", "Por favor llene todos los campos", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombres.Text))
            {
                DisplayAlert("Error", "Por favor ingrese el nombre", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellidos.Text))
            {
                DisplayAlert("Error", "Por favor ingrese el apellido", "OK");
                return false;
            }
            if (string.IsNullOrWhiteSpace(edad.Text))
            {
                DisplayAlert("Error", "Por favor ingrese la edad", "OK");
                return false;
            }
            if (string.IsNullOrWhiteSpace(correo.Text))
            {
                DisplayAlert("Error", "Por favor ingrese el correo", "OK");
                return false;
            }

            return true;
        }
    }
}
