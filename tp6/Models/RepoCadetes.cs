using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.Data.SQLite;
using System.IO;
using System.Web.Mvc;

namespace tp6.Models
{
    public class RepoCadetes
    {

  
    
        
          public List<Cadete> GetAll()
           {
                List<Cadete> listaDeCadetes = new List<Cadete>();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                using (var conexion = new SQLiteConnection(cadena)) { 
                    conexion.Open();
                    var command = conexion.CreateCommand();
                   
                    command.CommandText = "SELECT id, nombre, direccion, telefono, activo FROM cadete; ";
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var cadete1 = new Cadete();
                        cadete1.Id = Convert.ToInt32(reader["id"]);
                        cadete1.Direccion = reader["direccion"].ToString();
                        cadete1.Nombre = reader["Nombre"].ToString();
                        cadete1.Telefono = reader["Telefono"].ToString();
                        cadete1.Activo =Convert.ToInt32(reader["Activo"]);
                        listaDeCadetes.Add(cadete1);
                    }
                    reader.Close();
                    conexion.Close();
                }
            return listaDeCadetes;
           }

            /// <summary>
            /// Crea un usuario en la Base de datos
            /// </summary>
            /// <param name="usuario"></param>
            public void AltaCadete(Cadete nuevo)
            {
                try
                {
                    string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                    var conexion = new SQLiteConnection(cadena);
                    conexion.Open();
                    var command = conexion.CreateCommand();
                    command.CommandText = "Insert into cadete(nombre, direccion, telefono) values(@nombre,@direccion, @telefono) ";
                    command.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                    command.Parameters.AddWithValue("@direccion", nuevo.Direccion);
                    command.Parameters.AddWithValue("@telefono", nuevo.Telefono);
                    command.ExecuteNonQuery();
                    conexion.Close();
                    
                    
                }
                catch (Exception)
                {
                    throw;
                }
        }

           
            public Cadete GetCadete(int id)
            {
                var cadete1 = new Cadete();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
               
                command.CommandText = "SELECT id, nombre, direccion, telefono FROM cadete Where  id = @id;";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cadete1.Id = Convert.ToInt32(reader["Id"]);
                    cadete1.Nombre = reader["Nombre"].ToString();
                    cadete1.Telefono = reader["Telefono"].ToString();
                    cadete1.Direccion = reader["direccion"].ToString();
                } 
                reader.Close();
                conexion.Close();

                return cadete1;
            }

            /// <summary>
            /// Permite Modificar un usuario dado en Una base de Datos
            /// </summary>
            /// <param name="usuario"></param>
            public void ModificarCadete(Cadete cadete1)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = "UPDATE cadete SET nombre = @nombre, telefono = @telefono  , direccion = @direccion, activo = @activo  WHERE Id = @id";
                command.Parameters.AddWithValue("@nombre", cadete1.Nombre);
                command.Parameters.AddWithValue("@telefono", cadete1.Telefono);
                command.Parameters.AddWithValue("@id", cadete1.Id);
                command.Parameters.AddWithValue("@direccion", cadete1.Direccion);
                command.Parameters.AddWithValue("@activo", cadete1.Activo);

                command.ExecuteNonQuery();
                conexion.Close();
            }

           
            public void EliminarUsuario(int id)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = @"UPDATE cadete
                                    SET Activo = 0
                                    WHERE Id = @id;";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }
    }



