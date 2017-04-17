
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace AcheiVaga.PI4.Models.Usuario
{
    public  class Usuario
    {
        public ObjectId _id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string PlacaCarro { get; set; }
        public string pontuacao { get; set; }
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }




        public  Usuario(string NomeUsuario, string Senha, string PlacaCarro, string pontuacao, string email)
        {
            this.NomeUsuario = NomeUsuario;
            this.Senha = Senha;
            this.PlacaCarro = PlacaCarro;
            this.pontuacao = pontuacao;
            this.Email = email;
            this.Latitude = "";
            this.Longitude = "";




        }

        public Usuario()
        {

        }



        public string InserirUsuario(Usuario usuario)
        {

            if (VerificaDuplicidade(usuario.Email))
            {
                IMongoCollection<Usuario> ColecaoUsuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
                ColecaoUsuario.InsertOne(usuario);
                return "Cadastro efetuado";
            }
            else
            {
                return "Usuario já cadastrado";

            }
        }




        public string LogarUsuario(string email, string senha)
        {
            Usuario user = new Usuario();
            List<Usuario> usu = new List<Usuario>();

            if (email != null && senha != null)
            {
                List<Usuario> usuario = new List<Usuario>();
                IMongoCollection<Usuario> lista = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
                var filtro = Builders<Usuario>.Filter.Where(p => p.Email == email && p.Senha == senha);
                var Usuario = lista.Find<Usuario>(filtro).ToList();

                foreach (Usuario usuf in Usuario)
                {

                    usu.Add(usuf);

                }

                if (usu.Count == 1)
                    return ConvertListForJson(Usuario).ToString();
                else
                {
                    return "Usuario não encontrado";

                }

            }
            else
            {
                return "Email ou senha invalidos";
            }




        }






        public string ConvertListForJson(List<Usuario> list)
        {
            List<Usuario> ListUsuario = new List<Usuario>();

            foreach (Usuario usuario in list)
            {
                ListUsuario.Add(usuario);

            }

            var JsonSerializado = JsonConvert.SerializeObject(ListUsuario);
            return JsonSerializado;

        }

        public bool VerificaDuplicidade(string email)
        {
            List<Usuario> Usuario = new List<Models.Usuario.Usuario>();
            IMongoCollection<Usuario> Colecaousuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
            var filtro = Builders<Usuario>.Filter.Where(p => p.Email == email);
            var usuario = Colecaousuario.Find(filtro).Count();
            if (usuario > 0) { return false; } else { return true; }


        }

        public static bool AlterarEmail(string email,string senha,string novoemail)
        {

            IMongoCollection<Usuario> usuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
            var filtro = Builders<Usuario>.Filter.Where(p => p.Email == email && p.Senha == senha);
            var update = Builders<Usuario>.Update.Set("Email", novoemail);
            var result = usuario.UpdateOne(filtro,update);
            return true;

        }

        public static bool AlterarSenha(string email, string senha, string novasenha)
        {

            IMongoCollection<Usuario> usuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
            var filtro = Builders<Usuario>.Filter.Where(p => p.Email == email && p.Senha == senha);
            var update = Builders<Usuario>.Update.Set("Senha", novasenha);
            var result = usuario.UpdateOne(filtro, update);
            if (result != null)
                return true;
            else
                return false;


        }


        public static bool AlterarNome(string email, string senha, string novonome)
        {

            IMongoCollection<Usuario> usuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
            var filtro = Builders<Usuario>.Filter.Where(p => p.Email == email && p.Senha == senha);
            var update = Builders<Usuario>.Update.Set("Senha", novonome);
            var result = usuario.UpdateOne(filtro, update);
            return true;


        }




    }
}