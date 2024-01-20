using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Proyecto_P3.Utilidades
{
    public class ReservaMensajeria : ValueChangedMessage<ReservaMensaje>
    {
        public ReservaMensajeria(ReservaMensaje value) : base(value)
        {

        }
    }
}
