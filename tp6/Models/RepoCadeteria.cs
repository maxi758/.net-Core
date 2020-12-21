using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp6.Entidades;
using System.Data.SQLite;
using System.IO;

namespace tp6.Models
{
    public class RepoCadeteriaria
    {




        public List<Cadeteria> GetAll()
        {
            List<Cadeteria> listaDeCadeteria = new List<Cadeteria>();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            string instruccion = @"SELECT   Id, 
                                            Nombre, Direccion 
                                            Telefono 
                                            FROM Cadeteria";
            command.CommandText = instruccion;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Cadeteria1 = new Cadeteria();
                //Cadeteria1.Id = Convert.ToInt32(reader["Id"]);
                
                Cadeteria1.Nombre = reader["Nombre"].ToString();
                listaDeCadeteria.Add(Cadeteria1);
            }
            conexion.Close();
            return listaDeCadeteria;
        }

        /// <summary>
        /// Crea un Cadeteriaria en la Base de datos
        /// </summary>
        /// <param name="Cadeteriaria"></param>
        public void AltaCadeteriaria(Cadeteria Cadeteria1)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"INSERT INTO 
                                    Cadeteria (Nombre) 
                                    VALUES (@nombre, @telefono)";

            command.Parameters.AddWithValue("@nombre", Cadeteria1.Nombre);
            
            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Obtiene un Cadeteriaria del base de datos
        /// </summary>
        /// <param name="idCadeteriaria"></param>
        /// <returns></returns>
        public Cadeteria GetCadeteria(int id)
        {
            var Cadeteria1 = new Cadeteria();
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            string instruccion = @"SELECT Id, Nombre, Telefono 
                                   FROM Cadeteriaria
                                   Where  Id = @id";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                //Cadeteria1.Id = Convert.ToInt32(reader["IdCadeteriaria"]);
                Cadeteria1.Nombre = reader["Nombre"].ToString();
               
                reader.Close();
            }
            conexion.Close();

            return Cadeteria1;
        }

        /// <summary>
        /// Permite Modificar un Cadeteriaria dado en Una base de Datos
        /// </summary>
        /// <param name="Cadeteria"></param>
        public void ModificarCadeteria(Cadeteria Cadeteria1)
        {
            string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"UPDATE Cadeteria
                                    SET Nombre = @nombre, Telefono = @telefono                                        
                                    WHERE Id = @id";
            command.Parameters.AddWithValue("@nombre", Cadeteria1.Nombre);
            

            command.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Permite eliminar un Cadeteriaria de la base de datos
        /// </summary>
        /// <param name="idCadeteria"></param>
        /* public void EliminarCadeteriaria(int id)
         {
             string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "Datos\\Datos.db");
             var conexion = new SQLiteConnection(cadena);
             conexion.Open();
             var command = conexion.CreateCommand();
             command.CommandText = @"UPDATE Cadeteriaria 
                                 SET Activo = 0
                                 WHERE IdCadeteriaria = @idCadeteriaria;";
             command.Parameters.AddWithValue("@IdCadeteriaria", id);
             command.ExecuteNonQuery();
             conexion.Close();
         }*/

    }
}

}
