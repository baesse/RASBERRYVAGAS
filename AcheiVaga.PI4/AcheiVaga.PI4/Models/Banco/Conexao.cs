using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Banco
{
    public static class Conexao
    {
        public static MongoClient cliente = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase DataBase = cliente.GetDatabase("DBacheivaga");


        


       
    }
}