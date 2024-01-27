using Newtonsoft.Json;
using Proyecto_P3.Models;

namespace Proyecto_P3.Views;

public partial class EmpleadosHotel : ContentPage
{
	public EmpleadosHotel()
	{
		InitializeComponent();
	}

    private void displayEmpleadosInformation(List<Empleado> empleados)
    {
        if (empleados != null && empleados.Any())
        {
            foreach (var empleado in empleados)
            {
                empleadosLabel.Text += $"\n\nNombre de los empleados: {empleado.nombreEmpleado}\n";
            }
        }
        else
        {
            empleadosLabel.Text = "No existen empleados";
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())
            {
                string url = $"http://localhost:7204/api/Empleados";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);


                    displayEmpleadosInformation(empleados);
                }
            }
        }
    }
}