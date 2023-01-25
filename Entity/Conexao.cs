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
                var conexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Lanchonete;Data Source=SUPORTE-01\\SQLEXPRESS";
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