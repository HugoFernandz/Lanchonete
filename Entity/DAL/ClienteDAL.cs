using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.DAL
{
    public class ClienteDAL
    {
        public int Cadastro_C_Cliente(Pessoa user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Create_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.cpf;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.contato;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.email;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = user.status;

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
        public DataSet Cadastro_R_Cliente(Pessoa user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nomecliente ", SqlDbType.VarChar).Value = user.nome;
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
        public int Cadastro_U_Cliente(Pessoa user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Update_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = user.idpessoa;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.cpf;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.contato;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.email;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = user.status;

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
        public DataSet Cadastro_R_IDCliente(Pessoa user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_IDCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = user.idpessoa;

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