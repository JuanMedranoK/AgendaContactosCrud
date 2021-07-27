using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace Dato
{
    public class ConectarContactos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<Contactos> BuscarContactos(string search)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("BUSCARCONTACTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", search);
            cmd.Parameters.AddWithValue("@TELEFONO", search);
            cmd.Parameters.AddWithValue("@TELEFONO_TRABAJO", search);
            cmd.Parameters.AddWithValue("@CORREOELECTRONICO", search);
            cmd.Parameters.AddWithValue("@DIRECCION", search);
            leerFila = cmd.ExecuteReader();

            List<Contactos> Listar = new List<Contactos>();
            while (leerFila.Read())
            {
                Listar.Add(new Contactos
                {
                    Name = leerFila.GetString(0),
                    Phone = leerFila.GetString(1),
                    PhoneJob= leerFila.GetString(2),
                    Email= leerFila.GetString(3),
                    Direction = leerFila.GetString(4),
                    
                });
            }
            cn.Close();
            leerFila.Close();
            return Listar;
        }

        public void InsertarContactos(Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("INSERTARCONTACTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", contactos.Name);
            cmd.Parameters.AddWithValue("@TELEFONO", contactos.Phone);
            cmd.Parameters.AddWithValue("@TELEFONO_TRABAJO", contactos.PhoneJob);
            cmd.Parameters.AddWithValue("@CORREOELECTRONICO", contactos.Email);
            cmd.Parameters.AddWithValue("@DIRECCION", contactos.Direction);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void EditarContactos(Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("EDITARCONTACTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE",contactos.Name);
            cmd.Parameters.AddWithValue("@TELEFONO", contactos.Phone);
            cmd.Parameters.AddWithValue("@TELEFONOTRABAJO", contactos.PhoneJob);
            cmd.Parameters.AddWithValue("@CORREOELECTRONICO", contactos.Email);
            cmd.Parameters.AddWithValue("@DIRECCION", contactos.Direction);
            
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void EliminarContactos(Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("ELIMINARCONTACTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", contactos.Name);
            cmd.Parameters.AddWithValue("@TELEFONO", contactos.Phone);
            cmd.Parameters.AddWithValue("TELEFONOTRABAJO", contactos.PhoneJob);
            cmd.Parameters.AddWithValue("@CORREOELECTRONICO", contactos.Email);
            cmd.Parameters.AddWithValue("@DIRECCION", contactos.Direction);

            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
    
}
