using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.DAL
{
    public class LoginDAL
    {
        public int Cadastro_C_Login(Usuario user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.SP_I_Login"; // ALTERAR PROCEDURE
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = user.senha;

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
        public DataSet Cadastro_R_Login(Usuario user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Login";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = user.senha;

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
        public DataSet Cadastro_U_Login(Usuario user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Login";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = user.senha;

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
        public DataSet Cadastro_D_Login(Usuario user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.SP_I_Login";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = user.senha;

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