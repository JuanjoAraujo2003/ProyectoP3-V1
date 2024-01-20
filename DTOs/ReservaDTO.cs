using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_P3.DTOs
{
    public partial class ReservaDTO : ObservableObject
    {
        [ObservableProperty]
        public int idReserva;
        [ObservableProperty]
        public String nombre;
        [ObservableProperty]
        public String cedula;
        [ObservableProperty]
        public int numeroHuespedes;
        [ObservableProperty]
        public DateTime fechaEntrada;
        [ObservableProperty]
        public DateTime fechaSalida;
        [ObservableProperty]
        public string sede;

    }
}
