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
    public class DoctorRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Doctor> ListarDoctor()
        {
            List<Doctor> listadoDoctores = new List<Doctor>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "USP_S_ListarDoctor";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.CodDoctor = reader.GetInt32(0);
                    doctor.Nombres = reader.GetString(1);
                    doctor.CodEspecialidad = reader.GetInt32(2);
                    doctor.Sexo = reader.GetString(3);
                    doctor.Direccion = reader.GetString(4);
                    doctor.Telefono = reader.GetString(5);
                    doctor.Email = reader.GetString(6);
                    doctor.Colegiado = reader.GetString(7);
                    listadoDoctores.Add(doctor);
                }
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return listadoDoctores;
        }

        public string DeleteDoctor(int codDoctor)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion.AbrirConexion();

                sqlCommand.CommandText = "delete [USP_U_EliminarDoctor]";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@p_CodDoctor", codDoctor);
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

        public string InsertDoctor(Doctor doctor)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarDoctor]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Nombres", doctor.Nombres);
            comando.Parameters.AddWithValue("@p_CodEspecialidad", doctor.CodEspecialidad);
            comando.Parameters.AddWithValue("@p_Sexo", doctor.Sexo);
            comando.Parameters.AddWithValue("@p_Direccion", doctor.Direccion);
            comando.Parameters.AddWithValue("@p_Telefono", doctor.Telefono);
            comando.Parameters.AddWithValue("@p_Email", doctor.Email);
            comando.Parameters.AddWithValue("@p_Colegiado", doctor.Colegiado);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

        public string UpdateDoctor(Doctor doctor)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_U_ActualizarDoctor]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_Nombres", doctor.Nombres);
            comando.Parameters.AddWithValue("@p_CodEspecialidad", doctor.CodEspecialidad);
            comando.Parameters.AddWithValue("@p_Sexo", doctor.Sexo);
            comando.Parameters.AddWithValue("@p_Direccion", doctor.Direccion);
            comando.Parameters.AddWithValue("@p_Telefono", doctor.Telefono);
            comando.Parameters.AddWithValue("@p_Email", doctor.Email);
            comando.Parameters.AddWithValue("@p_Colegiado", doctor.Colegiado);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }

    }
}
