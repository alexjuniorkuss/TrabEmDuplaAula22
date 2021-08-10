using MvcAlexRodolfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Repository
{
    public class BaseDAO<T> where T : BaseModel
    {
        protected string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GitHub\TrabEmDuplaAula22\MvcAlexRodolfo\MvcAlexRodolfo\App_Data\Cadastros.mdf;Integrated Security=True";
        private static List<T> List = new List<T>();
        private static int Id = 1;

        public virtual void Create(T model)
        {
            List.Add(model);
        }
        public virtual List<T> Read()
        {
            return List;
        }
        public virtual T Read(int Id)
        {
            return List.Find(l => l.Id == Id);
        }
        public virtual void Update(T model)
        {
            int index = List.FindIndex(l => l.Id == model.Id);
            if (index != -1)
            {
                List[index] = model;
            }
        }
        public virtual void Delete(T model)
        {
            int index = List.FindIndex(l => l.Id == model.Id);
                if (index != -1)
                {
                    List.Remove(model);
                }
        }
        public virtual void ExecNonQuery(string comando)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = comando;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}