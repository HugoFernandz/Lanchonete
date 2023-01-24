using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.DAL
{
    public class ProdutoDAL
    {
        public int Cadastro_C_Produto(Produto user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.SP_I_Produto"; // ALTERAR PROCEDURE
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@preco", SqlDbType.VarChar).Value = user.preco;
                cmd.Parameters.Add("@quantidade", SqlDbType.VarChar).Value = user.quantidade;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = user.status;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.VarChar).Value = user.tipoproduto;

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
        public DataSet Cadastro_R_Produto(Produto user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.VarChar).Value = user.tipoproduto;

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
        public DataSet Cadastro_U_Produto(Produto user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@preco", SqlDbType.VarChar).Value = user.preco;
                cmd.Parameters.Add("@quantidade", SqlDbType.VarChar).Value = user.quantidade;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = user.status;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.VarChar).Value = user.tipoproduto;

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
        public DataSet Cadastro_D_Produto(Produto user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idproduto", SqlDbType.VarChar).Value = user.idproduto;

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