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
        public int Cadastro_C_Clientes(Pessoa user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.SP_I_Clientes"; // ALTERAR PROCEDURE
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.contato;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.cpf;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.email;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = user.status;
                cmd.Parameters.Add("@tipousuario", SqlDbType.VarChar).Value = user.tipousuario;

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
        public DataSet Cadastro_R_Clientes(Pessoa user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Clientes";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@tipousuario", SqlDbType.VarChar).Value = user.tipousuario;

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
        public DataSet Cadastro_U_Clientes(Pessoa user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Clientes";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.nome;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.contato;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.cpf;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.email;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = user.status;
                cmd.Parameters.Add("@tipousuario", SqlDbType.VarChar).Value = user.tipousuario;

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
        public DataSet Cadastro_D_Clientes(Pessoa user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Login";
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