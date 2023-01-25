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
        public DataSet Update (Usuario user)
        {
            try
            {
                DataSet consult = usuario.Cadastro_U_Usuario(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Delete (Usuario user)
        {
            try
            {
                DataSet consult = usuario.Cadastro_D_Usuario(user);
                return consult;
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
    }
}