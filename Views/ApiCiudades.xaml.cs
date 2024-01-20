using Newtonsoft.Json;
using Proyecto_P3.Models;

namespace Proyecto_P3.Views;

public partial class ApiCiudades : ContentPage
{
    public ApiCiudades()
    {
        InitializeComponent();
    }

    private void displayCityInformation(List<City> cities)
    {
        if (cities != null && cities.Any())
        {

            foreach (var city in cities)
            {
                cityLabel.Text += $"Nombre de la ciudad: {city.name}\n";

            }
        }
        else
        {
            cityLabel.Text = "No se encontraron ciudades.";
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())

            {

                client.DefaultRequestHeaders.Add("x-api-key", "Mltspp4Dthy/ShzqK+QT5g==WbAAnaGfAqYMmIrG");

                string url = $"https://api.api-ninjas.com/v1/city?country=US&limit=5";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)

                {
                    var json = await response.Content.ReadAsStringAsync();
                    var cities = JsonConvert.DeserializeObject<List<City>>(json);

                    displayCityInformation(cities);


                }
            }
        }
    }
}