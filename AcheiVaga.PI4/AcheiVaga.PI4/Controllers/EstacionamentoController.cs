using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcheiVaga.PI4.Controllers
{
    public class EstacionamentoController : ApiController
    {
        [HttpPost]
        public void InserirEstacionamento()
        {
            Models.Estacionamento Estacionamento = new Models.Estacionamento();
            Estacionamento.CadastrarEstacionamento();
            
        }

        [HttpPost]
        public void InserirVaga(string teste)
        {
            Models.Estacionamento Estacionamento = new Models.Estacionamento();
            Estacionamento.CadastrarEstacionamento();
            ai meu deus como é bom servir daloca
        }
    }
}
