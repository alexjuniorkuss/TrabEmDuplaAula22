using MvcAlexRodolfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Repository
{
    public class NotebookDAO  : BaseDAO<Notebook>
    {
        public override void Create(Notebook Model)
        {

            ExecNonQuery("Insert into Notebook " +
                        "(Marca, Modelo, Valor) " +
                        "values " +
                        $"('{Model.Marca}', '{Model.Modelo}', {Model.Valor.ToString(CultureInfo.InvariantCulture)});");
        }
        public override List<Notebook> Read()
        {
            List<Notebook> ListJog = new List<Notebook>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand())
                {
                    comand.Connection = conn;
                    comand.CommandText = "Select Id,Marca,Modelo,Valor from Notebook";
                    using (var DataReader = comand.ExecuteReader())
                    {
                        while (DataReader.Read())
                        {
                            Notebook model = new Notebook();
                            model.Id = Convert.ToInt32(DataReader["Id"]);
                            model.Marca = DataReader["Marca"].ToString();
                            model.Modelo = DataReader["Modelo"].ToString();
                            model.Valor = Convert.ToDecimal(DataReader["Valor"]);
                            ListJog.Add(model);
                        }
                    }
                }
            }
            return ListJog;
        }
        public override Notebook Read(int id)
        {
            Notebook model = new Notebook();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comand = new SqlCommand())
                {
                    comand.Connection = conn;
                    comand.CommandText = $"Select Id,Marca,Modelo,Valor from Notebook where Id = {id}";
                    using (var DataReader = comand.ExecuteReader())
                    {
                        while (DataReader.Read())
                        {
                            model.Id = Convert.ToInt32(DataReader["Id"]);
                            model.Marca = DataReader["Marca"].ToString();
                            model.Modelo = DataReader["Modelo"].ToString();
                            model.Valor = Convert.ToDecimal(DataReader["Valor"]);
                        }
                    }
                }
            }
            return model;
        }
        public override void Update(Notebook model)
        {
            ExecNonQuery("update Notebook " +
                         "set " +
                        $"Marca='{model.Marca}'," +
                        $"Modelo='{model.Modelo}'," +
                        $"Valor={model.Valor.ToString(CultureInfo.InvariantCulture)}" +
                        $"where Id = {model.Id};");
        }
        public void Delete(int id)
        {
            ExecNonQuery($"Delete From Notebook Where Id={id}");
        }
    }
}