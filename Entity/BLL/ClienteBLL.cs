using SistemaLoja01.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.BLL
{
    public class ClienteBLL
    {
        ClienteDAL client = new ClienteDAL();

        public int Create (Pessoa user)
        {
            try
            {
                int value = client.Cadastro_C_Clientes(user);
                
                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read (Pessoa user)
        {
            try
            {
                DataSet consult = client.Cadastro_R_Clientes(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Update (Pessoa user)
        {
            try
            {
                DataSet consult = client.Cadastro_U_Clientes(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Delete (Pessoa user)
        {
            try
            {
                DataSet consult = client.Cadastro_D_Clientes(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}