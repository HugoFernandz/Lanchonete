using SistemaLoja01.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.BLL
{
    public class ProdutoBLL
    {
        ProdutoDAL product = new ProdutoDAL();

        public int Create (Produto user)
        {
            try
            {
                int value = product.Cadastro_C_Produto(user);
                
                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read (Produto user)
        {
            try
            {
                DataSet consult = product.Cadastro_R_Produto(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Update (Produto user)
        {
            try
            {
                DataSet consult = product.Cadastro_U_Produto(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Delete (Produto user)
        {
            try
            {
                DataSet consult = product.Cadastro_D_Produto(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}