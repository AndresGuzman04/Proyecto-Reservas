using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;

namespace negocio
{
    public class NegocioHabitaciones
    {
        Habitaciones habitacionesN = new Habitaciones();

        public DataTable ObtenerHabitaciones() {
            return habitacionesN.ObtenerHabitaciones();
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario) {
            return habitacionesN.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);
        }

        public bool ModificarHabitacion(int id, int numero, string descripcion, int huespedes, int idUsuario) {
            return habitacionesN.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario);
        }

        public bool EliminarHabitacion(int id) { 
            return habitacionesN.EliminarHabitacion(id);
        }
    }
}
