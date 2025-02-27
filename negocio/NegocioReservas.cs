using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;

namespace negocio
{
    public class NegocioReservas
    {
        Reservas reservasN = new Reservas();
        Clientes dataClientes = new Clientes();
        Habitaciones dataHabitaciones = new Habitaciones();

        public DataTable ObtenerReservas()
        {
            return reservasN.ObtenerReservas();
        }
        public DataTable ObtenerCheckReservas(int id)
        {
            return reservasN.ObtenerCheckReservas(id);
        }


        public bool AgregarReserva(int id_reserva, int id_cliente, int id_habitacion,
            double precio, double descuento, DateTime checkin, DateTime checkout,
            DateTime fecha_registro, int id_usuario)
        {
            return reservasN.AgregarReserva(id_reserva, id_cliente, id_habitacion, precio, 
                descuento, checkin, checkout, fecha_registro, id_usuario);
        }

        public bool ModificarReserva(int id_reserva, int id_cliente, int id_habitacion,
            double precio, double descuento, DateTime checkin, DateTime checkout)
        {
            return reservasN.ModificarReserva(id_reserva, id_cliente, id_habitacion, precio, 
                descuento, checkin, checkout);
        }

        public bool EliminarReserva(int id_reserva)
        {
            return reservasN.EliminarReserva(id_reserva);
        }


        public DataTable ObtenerClientes()
        {
            return dataClientes.ObtenerCliente();
        }

        public DataTable ObtenerHabitacionPorHuespedes(int cantidad) {
            return dataHabitaciones.ObtenerHabitacionPorHuespedes(cantidad);
        }

    }
}
