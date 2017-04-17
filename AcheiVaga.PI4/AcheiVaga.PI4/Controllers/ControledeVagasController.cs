using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace AcheiVaga.PI4.Controllers
{
    public class ControledeVagasController : ApiController
    {



        //[HttpGet]
        //public string GetJsonVgasOcupadas()
        //{
        //    Models.Vaga vaga = new Models.Vaga();
        //   // return vaga.ListadeVagas();

        //}


        [HttpPost]
        public string PostNovaVaga()
        {
            Models.Vaga vaga = new Models.Vaga();
            vaga.CadastrodeVaga(5,0,0);
            return "Vaga cadastrada";
        }


        [HttpPut]
        public string SetOcupada(int id)
        {
            Models.Vaga vaga = new Models.Vaga();
            vaga.SetVagaOcupada(id);
            return "Vaga "+id+" ocupada";
        }

        [HttpPut]
        public string SetTipoVagas(int ini,int final)
        {
            Models.Vaga vaga = new Models.Vaga();
            vaga.SetVagaCobertaIntervalo(ini,final);

            StringBuilder mensagem = new StringBuilder();
            mensagem.Append("As vagas a seguir fora definadas para o tipo Coberto \n");


            for(int i = ini; i < final; i++)
            {

                mensagem.Append("Vaga:" + i);
                mensagem.Append("\n");


            }

            return mensagem.ToString();

        }

        [HttpGet]
        public string GetTodasAsVagas()
        {
            Models.Vaga vaga = new Models.Vaga();
            return vaga.RetornoVagaJsonByid(1);


        }


    }
}
