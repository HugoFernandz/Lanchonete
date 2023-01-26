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

        public int Create(Pessoa user)
        {
            try
            {
                int value = client.Cadastro_C_Cliente(user);

                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read(Pessoa user)
        {
            try
            {
                DataSet consult = client.Cadastro_R_Cliente(user);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Update(Pessoa user)
        {
            try
            {
                int value = client.Cadastro_U_Cliente(user);

                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Pessoa Read_ID(Pessoa user)
        {
            try
            {
                DataSet consult = client.Cadastro_R_IDCliente(user);

                Pessoa dadospessoa = new Pessoa();

                dadospessoa.idpessoa = Convert.ToInt32(consult.Tables[0].Rows[0]["IdCliente"].ToString());
                dadospessoa.nome = consult.Tables[0].Rows[0]["Nome"].ToString();
                dadospessoa.cpf = consult.Tables[0].Rows[0]["CPF"].ToString();
                dadospessoa.contato = consult.Tables[0].Rows[0]["Contato"].ToString();
                dadospessoa.email = consult.Tables[0].Rows[0]["Email"].ToString();
                dadospessoa.status = Convert.ToBoolean(consult.Tables[0].Rows[0]["Status"].ToString());

                return dadospessoa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}