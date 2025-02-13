using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class Habitaciones
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable ObtenerHabitaciones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM habitaciones", con))
                {
                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd)) { 
                        DA.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario) {
            
            using (SqlConnection con = new SqlConnection(connectionString)) {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO habitaciones " + 
                    "(numero, descripcion, huespedes, id_usuario) " + 
                    "Values (@numero, @descripcion, @huespedes, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@huespedes", huespedes);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool ModificarHabitacion(int id, int numero, string descripcion, int huespedes, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE habitaciones SET " +
                    "numero = @numero, " + 
                    "descripcion = @descripcion, " +
                    "huespedes = @huespedes, " +
                    "id_usuario = @id_Usuario " +
                    "WHERE id_habitaciones = @id_habitacion", con))
                {
                    cmd.Parameters.AddWithValue("@id_habitacion", id);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@huespedes", huespedes);
                    cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool EliminarHabitacion(int id) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from habitaciones where id_habitaciones = @id_habitaciones", con)) 
                {
                    cmd.Parameters.AddWithValue("@id_habitaciones", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
