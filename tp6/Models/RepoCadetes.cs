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
                   
                    command.CommandText = "SELECT idCadete, NombreCadete, direccion, telefono, activo FROM cadete; ";
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var cadete1 = new Cadete();
                        cadete1.Id = Convert.ToInt32(reader["idCadete"]);
                        cadete1.Direccion = reader["direccion"].ToString();
                        cadete1.Nombre = reader["NombreCadete"].ToString();
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
                    command.CommandText = "Insert into cadete(nombreCadete, direccion, telefono, activo) values(@nombre,@direccion, @telefono, 1) ";
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
               
                command.CommandText = "SELECT idCadete, nombreCadete, direccion, telefono FROM cadete Where  idCadete = @id;";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    cadete1.Id = Convert.ToInt32(reader["IdCadete"]);
                    cadete1.Nombre = reader["NombreCadete"].ToString();
                    cadete1.Telefono = reader["Telefono"].ToString();
                    cadete1.Direccion = reader["direccion"].ToString();
                } 
                reader.Close();
                conexion.Close();

                return cadete1;
            }
            public List<Pedido> GetPedidosDeCadete(int id)
            {
                
                List<Pedido> listaDePedidos = new List<Pedido>();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();

                command.CommandText = "SELECT idpedido, nombreCliente, observacion, EstadoPedido, TipoPedido FROM Pedido INNER JOIN Cadete using(IdCadete) INNER JOIN Cliente using(idCliente) WHERE idCadete = @id;";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var Pedido1 = new Pedido();
                    Pedido1.Cliente = new Cliente();
                    Pedido1.NumeroPedido = Convert.ToInt32(reader["idpedido"]);
                    Pedido1.Observacion = reader["Observacion"].ToString();
                    Pedido1.EstadoPedido = (Estado)Convert.ToInt32(reader["EstadoPedido"]);
                    Pedido1.Tipo = (TipoPedido)Convert.ToInt32(reader["TipoPedido"]);
                    Pedido1.Cliente.Nombre = reader["NombreCliente"].ToString();
                    listaDePedidos.Add(Pedido1);
                }
                reader.Close();
                conexion.Close();

                return listaDePedidos;
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
                command.CommandText = "UPDATE cadete SET nombreCadete = @nombre, telefono = @telefono  , direccion = @direccion, activo = @activo  WHERE IdCadete = @id";
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
                                    WHERE IdCadete = @id;";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }
    }



