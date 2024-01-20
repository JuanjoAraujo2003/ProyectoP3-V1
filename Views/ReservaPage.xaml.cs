using Proyecto_P3.ViewModels;
namespace Proyecto_P3.Views;

public partial class ReservaPage : ContentPage
{
	public ReservaPage(ReservaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}