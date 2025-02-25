using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;

namespace negocio
{
    public class NegocioCliente
    {
        Clientes clientesN = new Clientes();

        public DataTable ObtenerClientes()
        {
            return clientesN.ObtenerClientes();
        }

        public bool AgregarCliente(string nombre, int dui, int telefono, string correo, string departamento, DateTime fecha_registro, int id_usuario)
        {
            return clientesN.AgregarCliente(nombre , dui, telefono, correo, departamento, fecha_registro, id_usuario);
        }

        public bool ModificarCliente(int id, string nombre, int dui, int telefono, string correo, string departamento)
        {
            return clientesN.ModificarCliente(id, nombre, dui, telefono, correo, departamento);
        }

        public bool EliminarCliente(int id)
        {
            return clientesN.EliminarCliente(id);
        }
    }
}
