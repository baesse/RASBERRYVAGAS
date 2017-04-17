using AcheiVaga.PI4.Models.Usuario;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models
{
    public class Estacionamento
    {
        public ObjectId _Id { get; set; }
        public string NomeEstacionamento { get; set; }
        
        public List<Vaga> Vagas { get; set; }


        public Estacionamento(string Nome)
        {
            this.NomeEstacionamento = Nome;
           
            this.Vagas = new List<Vaga>();
            
        }
        public Estacionamento( )
        {

        }

        public void CadastrarEstacionamento()
        {
            IMongoCollection<Estacionamento> ColecaoEstacionamento = Banco.Conexao.DataBase.GetCollection<Estacionamento>("Estacionamento");
            Estacionamento Estacionamento = new Estacionamento("Minas");
            ColecaoEstacionamento.InsertOne(Estacionamento);



        }

        public void InserirVaga(Vaga vaga)
        {
            Estacionamento novavaga = new Estacionamento("Minas");
            IMongoCollection<Estacionamento> ColecaoEstacionamento = Banco.Conexao.DataBase.GetCollection<Estacionamento>("Estacionamento");            
            var filtro= Builders<Estacionamento>.Filter.Where(p => p.NomeEstacionamento == "Minas");
            novavaga.Vagas.Add(vaga);
            ColecaoEstacionamento.UpdateOne(filtro,null);

        }
    }
}