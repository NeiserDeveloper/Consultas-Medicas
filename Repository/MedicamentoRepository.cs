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
    public class MedicamentoRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Medicamentos> ListarMedicamento()
        {
            List<Medicamentos> listadoMedicamento = new List<Medicamentos>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "USP_S_ListarMedicamento";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Medicamentos medicamentos = new Medicamentos();
                    medicamentos.CodMedicamento = reader.GetInt32(0);
                    medicamentos.Nombre = reader.GetString(1);
                    medicamentos.Concentracion = reader.GetString(2);
                    medicamentos.Forma = reader.GetString(3);
                    medicamentos.Presentacion = reader.GetString(4);
                    medicamentos.precio = reader.GetDecimal(5);

                    listadoMedicamento.Add(medicamentos);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoMedicamento;
        }

        public string DeleteMedicamento(int codMedicamento)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "[USP_U_EliminarMedicamento]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@p_CodMedicamento", codMedicamento);
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

        public string InsertMedicamento(Medicamentos medicamentos)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarMedicamento]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Nombre", medicamentos.Nombre);
            comando.Parameters.AddWithValue("@p_Concentracion", medicamentos.Concentracion);
            comando.Parameters.AddWithValue("@p_Forma", medicamentos.Forma);
            comando.Parameters.AddWithValue("@p_Presentacion", medicamentos.Presentacion);
            comando.Parameters.AddWithValue("@p_Precio", medicamentos.precio);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string UpdateMedicamento(Medicamentos medicamentos)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarMedicamento]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CodMedicamento", medicamentos.CodMedicamento);
            comando.Parameters.AddWithValue("@p_Nombres", medicamentos.Nombre);
            comando.Parameters.AddWithValue("@p_Concentracion", medicamentos.Concentracion);
            comando.Parameters.AddWithValue("@p_Forma", medicamentos.Forma);
            comando.Parameters.AddWithValue("@p_Presentacion", medicamentos.Presentacion);
            comando.Parameters.AddWithValue("@p_Precio", medicamentos.precio);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

    }
}
