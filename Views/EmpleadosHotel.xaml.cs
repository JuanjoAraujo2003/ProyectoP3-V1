using Newtonsoft.Json;
using Proyecto_P3.Models;
using System.Diagnostics;

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
        try
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);

            var response = await httpClient.GetAsync("https://localhost:7204/api/Empleados");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var empleados = JsonConvert.DeserializeObject<List<Empleado>>(data);

                displayEmpleadosInformation(empleados);
            }
            else
            {
                Debug.WriteLine($"Error al obtener los datos: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"Error al obtener los datos: {ex.Message}");
            if (ex.InnerException != null)
            {
                Debug.WriteLine($"Mensaje de la excepción interna: {ex.InnerException.Message}");
            }
            Debug.WriteLine($"StackTrace: {ex.StackTrace}");

        }
        btnEmpleados.IsVisible = false;
    }
}