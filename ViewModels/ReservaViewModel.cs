using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Proyecto_P3.DataAccess;
using Proyecto_P3.DTOs;
using Proyecto_P3.Utilidades;
using Proyecto_P3.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_P3.Models.Proyecto_P3.Models;

namespace Proyecto_P3.ViewModels
{
    public partial class ReservaViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ReservaDbContext _dbContext;
        [ObservableProperty]
        private ReservaDTO reservaDto = new ReservaDTO();
        [ObservableProperty]
        private string tituloPagina;
        private int IdReserva;

        [ObservableProperty]
        private bool loadingEsVisible = false;

        public ReservaViewModel(ReservaDbContext context)
        {
            _dbContext = context;
            ReservaDto.FechaEntrada = DateTime.Now;
            ReservaDto.FechaSalida = DateTime.Now;
        }


        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = int.Parse(query["id"].ToString());
            IdReserva = id;
            if (IdReserva == 0)
            {
                TituloPagina = "Nueva Reserva";
            }
            else
            {
                TituloPagina = "Editar Reserva";
                LoadingEsVisible = true;
                await Task.Run(async () =>
                {
                    var encontrado = await _dbContext.Reservas.FirstAsync(e => e.IdReserva == IdReserva);
                    ReservaDto.IdReserva = encontrado.IdReserva;
                    ReservaDto.Nombre = encontrado.Nombre;
                    ReservaDto.Cedula = encontrado.Cedula;
                    ReservaDto.NumeroHuespedes = encontrado.NumeroHuespedes;
                    ReservaDto.FechaEntrada = encontrado.FechaEntrada;
                    ReservaDto.FechaSalida = encontrado.FechaSalida;
                    ReservaDto.Sede = encontrado.Sede;
              



                    MainThread.BeginInvokeOnMainThread(() => { LoadingEsVisible = false; });
                });
            }

        }
        [RelayCommand]
        private async Task Guardar()
        {
            LoadingEsVisible = true;
            ReservaMensaje mensaje = new ReservaMensaje();
            await Task.Run(async () =>
            {
                if (IdReserva == 0)
                {
                    var tbReserva = new Reserva
                    {
                        Nombre = ReservaDto.Nombre,
                        Cedula = ReservaDto.Cedula,
                        NumeroHuespedes = ReservaDto.NumeroHuespedes,
                        FechaEntrada = ReservaDto.FechaEntrada,
                        FechaSalida = ReservaDto.FechaSalida,
                        Sede = ReservaDto.Sede,
                    };
                    _dbContext.Reservas.Add(tbReserva);
                    await _dbContext.SaveChangesAsync();

                    ReservaDto.IdReserva = tbReserva.IdReserva;
                    mensaje = new ReservaMensaje()
                    {
                        EsCrear = true,
                        ReservaDto = ReservaDto,
                    };
                }
                else
                {
                    var encontrado = await _dbContext.Reservas.FirstAsync(e => e.IdReserva == IdReserva);
                    encontrado.Nombre = ReservaDto.Nombre;
                    encontrado.Cedula = ReservaDto.Cedula;
                    encontrado.NumeroHuespedes = ReservaDto.NumeroHuespedes;
                    encontrado.FechaEntrada = ReservaDto.FechaEntrada;
                    encontrado.FechaSalida = ReservaDto.FechaSalida;
                    encontrado.Sede = ReservaDto.Sede;

                    await _dbContext.SaveChangesAsync();

                    mensaje = new ReservaMensaje()
                    {
                        EsCrear = false,
                        ReservaDto = ReservaDto,
                    };
                }
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    LoadingEsVisible = false;
                    WeakReferenceMessenger.Default.Send(new ReservaMensajeria(mensaje));
                    await Shell.Current.Navigation.PopAsync();
                });

            });
        }
    }
}

