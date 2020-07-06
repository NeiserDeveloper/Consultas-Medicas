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
    public class EspecialidadRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Especialidad> ListarEspecialidad()
        {
            List<Especialidad> listadoEspecialidad = new List<Especialidad>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "USP_S_ListarEspecialidad";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.CodEspecialidad = reader.GetInt32(0);
                    especialidad.Nombre = reader.GetString(1);
                    listadoEspecialidad.Add(especialidad);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoEspecialidad;
        }

        public string DeleteEspecialidad(int codEspecialidad)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "delete [USP_U_EliminarEspecialidad]";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@p_CodEspecialidad", codEspecialidad);
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

        public string InsertEspecialidad(Especialidad especialidad)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarEspecialidad]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Nombres", especialidad.Nombre);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string UpdateEspecialidad(Especialidad especialidad)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarEspecialidad]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Nombres", especialidad.Nombre);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

    }
}
