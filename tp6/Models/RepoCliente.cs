using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.Data.SQLite;
using System.IO;

namespace tp6.Models
{
    public class RepoCliente
    {




        public List<Cliente> GetAll()
        {
            List<Cliente> listaDeCliente = new List<Cliente>();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "SELECT   Id,  Nombre, Direccion, Telefono FROM Cliente";
;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Cliente1 = new Cliente();
                Cliente1.Id = Convert.ToInt32(reader["Id"]);
                Cliente1.Direccion = reader["Direccion"].ToString();
                Cliente1.Telefono = reader["Telefono"].ToString();
                Cliente1.Nombre = reader["Nombre"].ToString();
                listaDeCliente.Add(Cliente1);
            }
            reader.Close();
            conexion.Close();
            return listaDeCliente;
        }

        /// <summary>
        /// Crea un Cliente en la Base de datos
        /// </summary>
        /// <param name="Cliente"></param>
        public void AltaCliente(Cliente Cliente1)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"INSERT INTO 
                                    Cliente (Nombre, telefono, direccion) 
                                    VALUES (@nombre, @telefono, @direccion)";

            command.Parameters.AddWithValue("@nombre", Cliente1.Nombre);
            command.Parameters.AddWithValue("@telefono", Cliente1.Telefono);
            command.Parameters.AddWithValue("@direccion", Cliente1.Direccion);

            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Obtiene un Cliente del base de datos
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Cliente GetCliente(int id)
        {
            var Cliente1 = new Cliente();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            string instruccion = @"SELECT Id, Nombre, Telefono 
                                   FROM Cliente
                                   Where  Id = @id";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Cliente1.Id = Convert.ToInt32(reader["Id"]);
                Cliente1.Nombre = reader["Nombre"].ToString();
               
                
            }
            reader.Close();
            conexion.Close();

            return Cliente1;
        }

        /// <summary>
        /// Permite Modificar un Cliente dado en Una base de Datos
        /// </summary>
        /// <param name="Cliente"></param>
        public void ModificarCliente(Cliente Cliente1)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"UPDATE Cliente
                                    SET Nombre = @nombre, Telefono = @telefono, direccion =@direccion                                        
                                    WHERE Id = @id";
            command.Parameters.AddWithValue("@nombre", Cliente1.Nombre);
            command.Parameters.AddWithValue("@telefono", Cliente1.Telefono);
            command.Parameters.AddWithValue("@direccion", Cliente1.Direccion);

            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Permite eliminar un Cliente de la base de datos
        /// </summary>
        /// <param name="idCliente"></param>
         public void EliminarCliente(int id)
         {
             string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
             var conexion = new SQLiteConnection(cadena);
             conexion.Open();
             var command = conexion.CreateCommand();
             command.CommandText = @"UPDATE Cliente
                                 SET Activo = 0
                                 WHERE Id = @id;";
             command.Parameters.AddWithValue("@Id", id);
             command.ExecuteNonQuery();
             conexion.Close();
         }

    }
}


