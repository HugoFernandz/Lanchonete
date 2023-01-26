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

        public int Create(Produto prod)
        {
            try
            {
                int value = product.Cadastro_C_Produto(prod);

                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read(Produto prod)
        {
            try
            {
                DataSet consult = product.Cadastro_R_Produto(prod);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Update(Produto prod)
        {
            try
            {
                int value = product.Cadastro_U_Produto(prod);

                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Produto Read_ID(Produto prod)
        {
            try
            {
                DataSet consult = product.Cadastro_R_IDProduto(prod);
                Produto produt = new Produto();

                produt.idproduto = Convert.ToInt32(consult.Tables[0].Rows[0]["IdProduto"].ToString());
                produt.nome = consult.Tables[0].Rows[0]["Nome"].ToString();
                produt.preco = Convert.ToDouble(consult.Tables[0].Rows[0]["Preco"].ToString());
                produt.quantidade = Convert.ToInt32(consult.Tables[0].Rows[0]["Quantidade"].ToString());
                produt.tipoproduto = Convert.ToInt32(consult.Tables[0].Rows[0]["TipoProduto"].ToString());
                produt.status = Convert.ToBoolean(consult.Tables[0].Rows[0]["Status"].ToString());

                return produt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}