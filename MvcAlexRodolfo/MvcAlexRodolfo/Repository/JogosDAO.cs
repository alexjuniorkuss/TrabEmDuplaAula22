using MvcAlexRodolfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Repository
{
    public class JogosDAO : BaseDAO<Jogos>
    {
       public override void Create(Jogos Model)
        {
            ExecNonQuery("Insert into Jogos " +
                        "(Nome, Genero, Valor,FaixaEtaria) " +
                        "values " +
                        $"('{Model.Nome}', '{Model.Genero}', {Model.Valor.ToString(CultureInfo.InvariantCulture)},{Model.FaixaEtaria});");
        }
        public override List<Jogos> Read()
        {
            List<Jogos> ListJog = new List<Jogos>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand())
                {
                    comand.Connection = conn;
                    comand.CommandText = "Select Id,Nome,Genero,Valor,FaixaEtaria from Jogos";
                    using (var DataReader = comand.ExecuteReader())
                    {
                        while (DataReader.Read())
                        {
                            Jogos model = new Jogos();
                            model.Id = Convert.ToInt32(DataReader["Id"]);
                            model.Nome = DataReader["Nome"].ToString();
                            model.Genero = DataReader["Genero"].ToString();
                            model.Valor = Convert.ToDecimal(DataReader["Valor"]);
                            model.FaixaEtaria = Convert.ToInt32(DataReader["FaixaEtaria"]);
                            ListJog.Add(model);
                        }
                    }
                }
            }
            return ListJog;
        }
        public override Jogos Read(int id)
        {
            Jogos model = new Jogos();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand())
                {
                    comand.Connection = conn;
                    comand.CommandText = $"Select Id,Nome,Genero,Valor,FaixaEtaria from Jogos where Id = {id}";
                    using (var DataReader = comand.ExecuteReader())
                    {
                        while (DataReader.Read())
                        {
                            model.Id = Convert.ToInt32(DataReader["Id"]);
                            model.Nome = DataReader["Nome"].ToString();
                            model.Genero = DataReader["Genero"].ToString();
                            model.Valor = Convert.ToDecimal(DataReader["Valor"]);
                            model.FaixaEtaria = Convert.ToInt32(DataReader["FaixaEtaria"]);
                        }
                    }
                }
            }
            return model;
        }
        public override void Update(Jogos model)
        {
            ExecNonQuery("update Jogos " +
                         "set " +
                        $"Nome='{model.Nome}'," +
                        $"Genero='{model.Genero}'," +
                        $"Valor={model.Valor}," +
                        $"FaixaEtaria={model.FaixaEtaria}" +
                        $"where {model.Id};");
        }
        public  void Delete(int id)
        {
            ExecNonQuery($"Delete From Jogos Where Id={id}");
        }
        
    }
}