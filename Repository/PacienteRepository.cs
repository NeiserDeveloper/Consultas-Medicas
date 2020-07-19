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
    public class PacienteRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Pacientes> ListarPacientes()
        {
            List<Pacientes> listadoPacientes = new List<Pacientes>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "USP_S_ListarPacientes";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Pacientes pacientes = new Pacientes();
                    pacientes.CodPaciente = reader.GetInt32(0);
                    pacientes.Documento = reader.GetInt32(1);
                    pacientes.Nombres = reader.GetString(2);
                    //pacientes.FechaNacimiento = reader.GetString(3);
                    pacientes.Sexo = reader.GetString(4);
                    pacientes.Direccion = reader.GetString(5);
                    pacientes.Telefono = reader.GetString(6);
                    pacientes.Email = reader.GetString(7);
                    listadoPacientes.Add(pacientes);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoPacientes;
        }

        public string DeletePatient(int codPaciente)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "[USP_U_EliminarPaciente]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@p_CodPaciente", codPaciente);
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

        public string InsertPatient(Pacientes paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarPaciente]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Documento", paciente.Documento);
            comando.Parameters.AddWithValue("@p_Nombres", paciente.Nombres);
            comando.Parameters.AddWithValue("@p_FechaNaci", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@p_Sexo", paciente.Sexo);
            comando.Parameters.AddWithValue("@p_Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@p_Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("@p_Email", paciente.Email);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string UpdatePatient(Pacientes paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarPaciente]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CodPaciente", paciente.CodPaciente);
            comando.Parameters.AddWithValue("@p_Documento", paciente.Documento);
            comando.Parameters.AddWithValue("@p_Nombres", paciente.Nombres);
            comando.Parameters.AddWithValue("@p_FechaNaci", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@p_Sexo", paciente.Sexo);
            comando.Parameters.AddWithValue("@p_Direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@p_Telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("@p_Email", paciente.Email);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

    }
}
