using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class Reservas
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable ObtenerReservas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT 
                reserva.id_reserva,
                cliente.nombre AS Cliente,
                habitaciones.numero AS Habitacion_Numero,
                reserva.precio,
                reserva.descuento,
                reserva.checkin,
                reserva.checkout,
                reserva.fecha_registro,
                reserva.id_usuario
            FROM reserva
            INNER JOIN habitaciones ON reserva.id_habitacion = habitaciones.id_habitaciones
            INNER JOIN cliente ON reserva.id_cliente = cliente.id_cliente", con))
                {
                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DA.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarReserva(int id_reserva, int id_cliente, int id_habitacion, 
            double precio, double descuento, DateTime checkin, DateTime checkout, 
            DateTime fecha_registro, int id_usuario)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO reserva " +
                    "(id_reserva, id_cliente, id_habitacion, precio, descuento, "+
                    "checkin, checkout, fecha_registro, id_usuario) " +
                    "Values (@id_reserva, @id_cliente, @id_habitacion, @precio, @descuento, " +
                    "@checkin, @checkout, @fecha_registro, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool ModificarReserva(int id_reserva, int id_cliente, int id_habitacion,
            double precio, double descuento, DateTime checkin, DateTime checkout)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE reserva SET " +
                    "id_cliente = @id_cliente, " +
                    "id_habitacion = @id_habitacion, " +
                    "precio = @precio, " +
                    "descuento = @descuento, " +
                    "checkin = @checkin, " +
                    "checkin = @checkin " +
                    "WHERE id_reserva = @id_reserva", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool EliminarReserva(int id_reserva)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM reserva WHERE id_reserva = @id_reserva", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", id_reserva);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public DataTable ObtenerCheckReservas(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT 
                reserva.id_reserva,
                cliente.nombre AS Cliente,
                habitaciones.numero AS Habitacion_Numero,
                reserva.precio,
                reserva.descuento,
                reserva.checkin,
                reserva.checkout,
                reserva.fecha_registro,
                reserva.id_usuario
            FROM reserva
            INNER JOIN habitaciones ON reserva.id_habitacion = habitaciones.id_habitaciones
            INNER JOIN cliente ON reserva.id_cliente = cliente.id_cliente "+ 
            "WHERE reserva.id_reserva = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DA.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}
