using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.Data.SQLite;
using System.IO;

namespace tp6.Models
{
    public class RepoCadetes
    {

  
    
        
          public List<Cadete> GetAll()
            {
                List<Cadete> listaDeCadetes = new List<Cadete>();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                string instruccion = @"SELECT   Id, 
                                            Nombre, Direccion 
                                            Telefono 
                                            FROM cadete";
                command.CommandText = instruccion;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cadete1 = new Cadete();
                    //cadete1.Id = Convert.ToInt32(reader["Id"]);
                    cadete1.Direccion = reader["Direccion"].ToString();
                    cadete1.Nombre = reader["Nombre"].ToString();
                    cadete1.Telefono = reader["Telefono"].ToString();
                    listaDeCadetes.Add(cadete1);
                }
                conexion.Close();
                return listaDeCadetes;
            }

            /// <summary>
            /// Crea un usuario en la Base de datos
            /// </summary>
            /// <param name="usuario"></param>
            public void AltaCadete(Cadete cadete1)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = @"INSERT INTO 
                                    cadete (Nombre, Telefono) 
                                    VALUES (@nombre, @telefono)";

                command.Parameters.AddWithValue("@nombre", cadete1.Nombre);
                command.Parameters.AddWithValue("@telefono", cadete1.Telefono);
                command.ExecuteNonQuery();
                conexion.Close();
            }

           
            public Cadete GetCadete(int id)
            {
                var cadete1 = new Cadete();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                string instruccion = @"SELECT Id, Nombre, Telefono 
                                   FROM Usuarios
                                   Where  Id = @id";
                command.CommandText = instruccion;
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //cadete1.Id = Convert.ToInt32(reader["IdUsuario"]);
                    cadete1.Nombre = reader["Nombre"].ToString();
                    cadete1.Telefono = reader["Telefono"].ToString();
                reader.Close();
                }
                conexion.Close();

                return cadete1;
            }

            /// <summary>
            /// Permite Modificar un usuario dado en Una base de Datos
            /// </summary>
            /// <param name="usuario"></param>
            public void ModificarCadete(Cadete cadete1)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = @"UPDATE cadete
                                    SET Nombre = @nombre, Telefono = @telefono                                        
                                    WHERE Id = @id";
                command.Parameters.AddWithValue("@nombre", cadete1.Nombre);
                command.Parameters.AddWithValue("@telefono", cadete1.Telefono);
                command.Parameters.AddWithValue("@id", cadete1.Id);

                command.ExecuteNonQuery();
                conexion.Close();
            }

           
           /* public void EliminarUsuario(int id)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = @"UPDATE Usuarios 
                                    SET Activo = 0
                                    WHERE IdUsuario = @idUsuario;";
                command.Parameters.AddWithValue("@IdUsuario", id);
                command.ExecuteNonQuery();
                conexion.Close();
            }*/

        }
    }

}

