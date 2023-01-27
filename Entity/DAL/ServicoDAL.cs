using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.DAL
{
    public class ServicoDAL
    {
        public int Cadastro_C_Servico(Servico servico)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Create_Servico";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nomecliente", SqlDbType.VarChar).Value = servico.nomecliente;
                cmd.Parameters.Add("@nomeproduto", SqlDbType.VarChar).Value = servico.nomeproduto;
                cmd.Parameters.Add("@valorproduto", SqlDbType.VarChar).Value = servico.valorproduto;
                cmd.Parameters.Add("@formapagamento", SqlDbType.VarChar).Value = servico.Formapagamento;
                cmd.Parameters.Add("@valortotal", SqlDbType.VarChar).Value = servico.valortotal;
                cmd.Parameters.Add("@quantidade", SqlDbType.Int).Value = servico.quantidade;

                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();

                int idRetorno = 1;

                return idRetorno;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao incluir dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar dados: " + ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public DataSet Cadastro_R_Servico(Servico servico)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_Servico";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nomecliente", SqlDbType.VarChar).Value = servico.nomecliente;
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);

                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}