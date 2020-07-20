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
    public class AtenderConsultaRepository
    {
        private ConexionBD conexion = new ConexionBD();
        public string InsertAtenderConsulta(AtenderConsulta atenderConsulta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "[USP_I_RegistrarAtenderConsulta]";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@p_CodMedicamento", atenderConsulta.CodMedicamento);
            comando.Parameters.AddWithValue("@p_Indicacion", atenderConsulta.Indicacion);
            comando.Parameters.AddWithValue("@p_FechaAtencion", atenderConsulta.FechaAtencion);
            comando.Parameters.AddWithValue("@p_CodConsulta", atenderConsulta.CodConsulta);
            comando.Parameters.AddWithValue("@p_CodDoctor", atenderConsulta.CodDoctor);
            comando.Parameters.AddWithValue("@p_Examen", atenderConsulta.Examen);
            comando.Parameters.AddWithValue("@p_Diagnostico", atenderConsulta.Diagnostico);
            comando.Parameters.AddWithValue("@p_EstadoConsulta", atenderConsulta.EstadoConsulta);
            comando.ExecuteNonQuery();


            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return "OK";
        }
    }
}
