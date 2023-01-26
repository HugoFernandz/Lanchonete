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
        public int Cadastro_C_Produto(Produto produto)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Create_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = produto.nome;
                cmd.Parameters.Add("@preco", SqlDbType.VarChar).Value = produto.preco;
                cmd.Parameters.Add("@quantidade", SqlDbType.Int).Value = produto.quantidade;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.Int).Value = produto.tipoproduto;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = produto.status;

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
        public DataSet Cadastro_R_Produto(Produto produto)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nomeproduto ", SqlDbType.VarChar).Value = produto.nome;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.VarChar).Value = produto.tipoproduto;
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
        public int Cadastro_U_Produto(Produto produto)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Update_Produto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idproduto", SqlDbType.Int).Value = produto.idproduto;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = produto.nome;
                cmd.Parameters.Add("@preco", SqlDbType.VarChar).Value = produto.preco;
                cmd.Parameters.Add("@quantidade", SqlDbType.Int).Value = produto.quantidade;
                cmd.Parameters.Add("@tipoproduto", SqlDbType.Int).Value = produto.tipoproduto;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = produto.status;

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
        public DataSet Cadastro_R_IDProduto(Produto produto)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_IDProduto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idproduto", SqlDbType.Int).Value = produto.idproduto;

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