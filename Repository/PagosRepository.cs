using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PagosRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Pagos> ListarPagos()
        {
            List<Pagos> listadoPagos = new List<Pagos>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "[USP_S_ListarPagos]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Pagos pagos = new Pagos();
                    pagos.CodPago = reader.GetInt32(0);
                    pagos.Fecha = reader.GetDateTime(1);
                    pagos.CodTipoPago = reader.GetInt32(2);
                    pagos.CodConsulta = reader.GetInt32(3);
                    pagos.Monto = reader.GetDecimal(5);

                    listadoPagos.Add(pagos);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoPagos;
        }

        public string DeletePagos(int codPagos)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "[USP_U_EliminarPago]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@p_CodPago", codPagos);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return "OK";
        }

        public string InsertPagos(Pagos pagos)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarPago]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Fecha", pagos.Fecha);
            comando.Parameters.AddWithValue("@p_CodTipoPago", pagos.CodTipoPago);
            comando.Parameters.AddWithValue("@p_CodConsulta", pagos.CodConsulta);
            comando.Parameters.AddWithValue("@p_Monto", pagos.Monto);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string UpdatePagos(Pagos pagos)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarPago]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CodPago", pagos.CodPago);
            comando.Parameters.AddWithValue("@p_Fecha", pagos.Fecha);
            comando.Parameters.AddWithValue("@p_CodTipoPago", pagos.CodTipoPago);
            comando.Parameters.AddWithValue("@p_CodConsulta", pagos.CodConsulta);
            comando.Parameters.AddWithValue("@p_Monto", pagos.Monto);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

    }
}
