namespace Proyecto_P3.Views;

public partial class Contacto : ContentPage
{
    public Contacto()
    {
        InitializeComponent();
    }

    private void OnShowContactClicked(object sender, EventArgs e)
    {
        string direccionContacto = "Avenida de las tukardas y Resistencia";
        string contactEmail = "TukiHotel@gmail.com";
        string contactPhone = "099-485-7894";

        MostrarContacto(direccionContacto, contactEmail, contactPhone);

        btnMostrarContacto.IsVisible = false;
    }


    public void MostrarContacto(string direccion, string email, string telefono)
    {
        lblDireccion.Text = $"Direccion: {direccion}";
        lblEmail.Text = $"Email: {email}";
        lblPhone.Text = $"Teléfono: {telefono}";
    }
}