using SistemaLoja01.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usuario = new UsuarioDAL();

        public int Create (Usuario user)
        {
            try
            {
                int value = usuario.Cadastro_C_Usuario(user);
                
                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read (Usuario user)
        {
            try
            {
                DataSet consult = usuario.Cadastro_R_Usuario(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Update (Usuario user)
        {
            try
            {
                int value = usuario.Cadastro_U_Usuario(user);

                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet ReadLogin(Usuario user)
        {
            try
            {
                DataSet consult = usuario.Cadastro_R_Login(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Usuario Read_ID(Usuario user)
        {
            try
            {
                DataSet consult = usuario.Cadastro_R_IDUsuario(user);

                Usuario dadosusuario = new Usuario();
                dadosusuario.pessoa = new Pessoa();

                dadosusuario.idusuario = Convert.ToInt32(consult.Tables[0].Rows[0]["IdUsuario"].ToString());
                dadosusuario.login = consult.Tables[0].Rows[0]["Login"].ToString();
                dadosusuario.pessoa.nome = consult.Tables[0].Rows[0]["Nome"].ToString();
                dadosusuario.pessoa.cpf = consult.Tables[0].Rows[0]["CPF"].ToString();
                dadosusuario.pessoa.contato = consult.Tables[0].Rows[0]["Contato"].ToString();
                dadosusuario.pessoa.email = consult.Tables[0].Rows[0]["Email"].ToString();
                dadosusuario.pessoa.tipousuario = Convert.ToInt32(consult.Tables[0].Rows[0]["TipoUsuario"].ToString());
                dadosusuario.pessoa.status = Convert.ToBoolean(consult.Tables[0].Rows[0]["Status"].ToString());

                return dadosusuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}