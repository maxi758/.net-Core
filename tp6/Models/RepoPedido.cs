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
    public class RepoPedidos
    {

  
    
        
          public List<Pedido> GetAll()
           {
                List<Pedido> listaDePedidos = new List<Pedido>();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                using (var conexion = new SQLiteConnection(cadena)) { 
                    conexion.Open();
                    var command = conexion.CreateCommand();
                   
                    command.CommandText = "SELECT idpedido, nombrecliente, nombrecadete, observacion, EstadoPedido, TipoPedido FROM Pedido INNER JOIN Cadete using (idCadete) INNER JOIN Cliente using(idCliente); ";
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var Pedido1 = new Pedido();
                        Pedido1.Cliente = new Cliente();
                        Pedido1.Cadete = new Cadete();
                        Pedido1.NumeroPedido = Convert.ToInt32(reader["idpedido"]);
                        Pedido1.Observacion = reader["Observacion"].ToString();
                        
                        Pedido1.Cadete.Nombre = reader["NombreCadete"].ToString();
                        Pedido1.Cliente.Nombre = reader["NombreCliente"].ToString();
                        Pedido1.EstadoPedido = (Estado)Convert.ToInt32(reader["EstadoPedido"]);
                        Pedido1.Tipo = (TipoPedido)Convert.ToInt32(reader["TipoPedido"]);
                        listaDePedidos.Add(Pedido1);
                    }
                    reader.Close();
                    conexion.Close();
                }
            return listaDePedidos;
           }

            /// <summary>
            /// Crea un usuario en la Base de datos
            /// </summary>
            /// <param name="usuario"></param>
            public void AltaPedido(Pedido nuevo)
            {
                try
                {
                    string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                    var conexion = new SQLiteConnection(cadena);
                    conexion.Open();
                    var command = conexion.CreateCommand();
                    command.CommandText = "Insert into Pedido(idcliente, idcadete, observacion, EstadoPedido, TipoPedido) values(@idcli, @idcad, @observ, @EstadoPedido, @TipoPedido) ";
                    command.Parameters.AddWithValue("@idcli", nuevo.Cliente.Id);
                    command.Parameters.AddWithValue("@idcad", nuevo.Cadete.Id);
                    command.Parameters.AddWithValue("@observ", nuevo.Observacion);
                    command.Parameters.AddWithValue("@EstadoPedido", nuevo.EstadoPedido);
                    command.Parameters.AddWithValue("@TipoPedido", nuevo.Tipo);
                    command.ExecuteNonQuery();
                    conexion.Close();
                    
                    
                }
                catch (Exception)
                {
                    throw;
                }
        }

           
            public Pedido GetPedido(int id)
            {
                var Pedido1 = new Pedido();
                
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
               
                command.CommandText = "SELECT idpedido, observacion, EstadoPedido, TipoPedido FROM Pedido  WHERE idPedido = @id;";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    Pedido1.NumeroPedido = Convert.ToInt32(reader["idpedido"]);
                    Pedido1.Observacion = reader["Observacion"].ToString();
                    
                    Pedido1.EstadoPedido = (Estado)Convert.ToInt32(reader["EstadoPedido"]);
                    Pedido1.Tipo = (TipoPedido)Convert.ToInt32(reader["TipoPedido"]);
              
                } 
                reader.Close();
                conexion.Close();

                return Pedido1;
            }

            /// <summary>
            /// Permite Modificar un usuario dado en Una base de Datos
            /// </summary>
            /// <param name="usuario"></param>
            public void ModificarPedido(Pedido Pedido)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = "UPDATE Pedido SET observacion = @observ ,EstadoPedido = @estado, TipoPedido = @tipoPedido  WHERE IdPedido = @id";
                command.Parameters.AddWithValue("@id", Pedido.NumeroPedido);
                command.Parameters.AddWithValue("@observ", Pedido.Observacion);
                command.Parameters.AddWithValue("@Estado", Pedido.EstadoPedido);
                command.Parameters.AddWithValue("@TipoPedido", Pedido.Tipo);

                command.ExecuteNonQuery();
                conexion.Close();
            }

           
            public void EliminarPedido(int id)
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), "datos\\cadeteria.db");
                var conexion = new SQLiteConnection(cadena);
                conexion.Open();              
                var command = conexion.CreateCommand();
                command.CommandText = "DELETE FROM Pedido WHERE IdPedido = @id;";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }
    }



