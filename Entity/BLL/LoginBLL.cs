using SistemaLoja01.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.BLL
{
    public class LoginBLL
    {
        public int Create (Usuario user)
        {
            try
            {
                LoginDAL login = new LoginDAL();
                int value = login.Cadastro_C_Login(user);

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
                LoginDAL login = new LoginDAL();
                DataSet consult = login.Cadastro_R_Login(user);

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
                LoginDAL login = new LoginDAL();
                DataSet consult = login.Cadastro_U_Login(user);

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
                LoginDAL login = new LoginDAL();
                DataSet consult = login.Cadastro_D_Login(user);

                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}