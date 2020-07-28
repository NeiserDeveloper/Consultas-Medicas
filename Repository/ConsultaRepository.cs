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
    public class ConsultaRepository
    {
        private ConexionBD conexion = new ConexionBD();

        public List<Consulta> ListarConsulta()
        {
            List<Consulta> listadoConsulta = new List<Consulta>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "USP_S_ListarConsultas";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Consulta consulta = new Consulta();
                    consulta.CodConsulta = reader.GetInt32(0);
                    consulta.Tipo = reader.GetInt32(1);
                    consulta.TipoTexto = reader.GetString(2);
                    consulta.CodPaciente = reader.GetInt32(3);
                    consulta.Paciente = reader.GetString(4);
                    consulta.DireccionPaciente = reader.GetString(5);
                    consulta.Peso = reader.GetDecimal(6);
                    consulta.Estatura = reader.GetDecimal(7);
                    consulta.Fecha = reader.GetDateTime(8);
                    consulta.FechaFormato = reader.GetString(9);
                    consulta.Descripcion = reader.GetString(10);
                    consulta.EstadoConsulta = reader.GetInt32(11);
                    consulta.EstConsultaTexto = reader.GetString(12);
                    //consulta.Estado = reader.GetInt32(13);
                    consulta.Observacion = reader.GetString(14);
                    listadoConsulta.Add(consulta);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoConsulta;
        }

        public string DeleteConsulta(int codConsulta)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "[USP_U_EliminarConsulta]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@p_CodConsulta", codConsulta);
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

        public string InsertConsulta(Consulta consulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarConsulta]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_tipo", consulta.Tipo);
            comando.Parameters.AddWithValue("@p_CodPaciente", consulta.CodPaciente);
            comando.Parameters.AddWithValue("@p_Peso", consulta.Peso);
            comando.Parameters.AddWithValue("@p_Estatura", consulta.Estatura);
            comando.Parameters.AddWithValue("@p_Fecha", consulta.Fecha);
            comando.Parameters.AddWithValue("@p_Descripcion", consulta.Descripcion);
            comando.Parameters.AddWithValue("@p_Observacion", consulta.Observacion);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string InsertConsultaVirtual(Consulta.SaveVirtual saveVirtual)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarConsultaVirtual]";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@p_Nombres", saveVirtual.Nombres);
            comando.Parameters.AddWithValue("@p_FechaNaci", saveVirtual.FechaNacimiento);
            comando.Parameters.AddWithValue("@p_Sexo", saveVirtual.Sexo);
            comando.Parameters.AddWithValue("@p_Direccion", saveVirtual.Direccion);
            comando.Parameters.AddWithValue("@p_Telefono", saveVirtual.Telefono);
            comando.Parameters.AddWithValue("@p_Peso", saveVirtual.Peso);
            comando.Parameters.AddWithValue("@p_Estatura", saveVirtual.Estatura);
            comando.Parameters.AddWithValue("@p_Fecha", saveVirtual.Fecha);
            comando.Parameters.AddWithValue("@p_Descripcion", saveVirtual.Descripcion);
            comando.Parameters.AddWithValue("@p_Observacion", saveVirtual.Observacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return "OK";
        }

        public string UpdateConsulta(Consulta consulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarConsulta]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CodConsulta", consulta.CodConsulta);
            comando.Parameters.AddWithValue("@p_tipo", consulta.Tipo);
            comando.Parameters.AddWithValue("@p_CodPaciente", consulta.CodPaciente);
            comando.Parameters.AddWithValue("@p_Peso", consulta.Peso);
            comando.Parameters.AddWithValue("@p_Estatura", consulta.Estatura);
            comando.Parameters.AddWithValue("@p_Fecha", consulta.Fecha);
            comando.Parameters.AddWithValue("@p_Descripcion", consulta.Descripcion);
            comando.Parameters.AddWithValue("@p_Observacion", consulta.Observacion);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }



    }

}
