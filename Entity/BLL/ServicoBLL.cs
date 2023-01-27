using SistemaLoja01.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity.BLL
{
    public class ServicoBLL
    {
        ServicoDAL servico = new ServicoDAL();

        public int Create (Servico serv)
        {
            try
            {
                int value = servico.Cadastro_C_Servico(serv);
                
                if (value == 1) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Read (Servico serv)
        {
            try
            {
                DataSet consult = servico.Cadastro_R_Servico(serv);
                return consult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}