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
    public class LoginRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public Usuario.Login Authentication(string usuario, string password)
        {
            Usuario.Login dataLogin = new Usuario.Login();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexion.AbrirConexion();
                sqlCommand.CommandText = "[USP_S_Authentication]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@p_Usuario", usuario);
                sqlCommand.Parameters.AddWithValue("@p_Password", password);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                reader.Read();
                dataLogin = new Usuario.Login();
                dataLogin.CodUsuario = reader.GetInt32(0);
                dataLogin.Usuario = reader.GetString(1);
                dataLogin.Nombre = reader.GetString(2);
                dataLogin.CodPerfil = reader.GetInt32(3);
                dataLogin.Perfil = reader.GetString(4);
                conexion.CerrarConexion();

                return dataLogin;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }

        }
    }
}
