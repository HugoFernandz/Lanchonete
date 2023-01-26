using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.DAL
{
    public class UsuarioDAL
    {
        public int Cadastro_C_Usuario(Usuario user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Create_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = user.senha;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.pessoa.nome;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.pessoa.cpf;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.pessoa.contato;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.pessoa.email;
                cmd.Parameters.Add("@tipousuario", SqlDbType.Int).Value = user.pessoa.tipousuario;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = user.pessoa.status;

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
        public DataSet Cadastro_R_Usuario(Usuario user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nomeusuario", SqlDbType.VarChar).Value = user.pessoa.nome;
                cmd.Parameters.Add("@tipousuario", SqlDbType.VarChar).Value = user.pessoa.tipousuario;

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
        public int Cadastro_U_Usuario(Usuario user)
        {
            Conexao conexao = new Conexao();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.Update_Usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = user.idusuario;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = user.login;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = user.pessoa.nome;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = user.pessoa.cpf;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = user.pessoa.contato;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.pessoa.email;
                cmd.Parameters.Add("@tipousuario", SqlDbType.Int).Value = user.pessoa.tipousuario;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = user.pessoa.status;

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

                cmd.CommandText = "dbo.Read_Login";
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
        public DataSet Cadastro_R_IDUsuario(Usuario user)
        {
            Conexao conexao = new Conexao();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.Read_IDUsuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = user.idusuario;

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