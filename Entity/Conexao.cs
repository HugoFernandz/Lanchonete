using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Conexao
    {
        public static string StrConexao
        {
            get
            {
                var conexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Projeto01;Data Source=DESKTOP-5ACM8V6"; // BUSCAR NOVO LINK
                return conexao;
            }
        }
        public SqlConnection cn = new SqlConnection(StrConexao);
        public SqlConnection Conectar()
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
            return cn;
        }
        public void Desconectar()
        {
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }
    }
}