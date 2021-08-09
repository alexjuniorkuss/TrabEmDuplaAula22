using MvcAlexRodolfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Repository
{
    public class BaseRepository<T> where T : BaseModel
    {
        private static List<T> List = new List<T>();
        private static int Id = 1;

        public void Create(T model)
        {
            model.Id = Id;
            Id++;
            List.Add(model);
        }
        public List<T> Read()
        {
            return List;
        }
        public T Read(int Id)
        {
            return List.Find(l => l.Id == Id);
        }
        public void Update(T model)
        {
            int index = List.FindIndex(l => l.Id == model.Id);
            if (index != -1)
            {
                List[index] = model;
            }
        }
        public void Delete(T model)
        {
            int index = List.FindIndex(l => l.Id == model.Id);
                if (index != -1)
                {
                    List.Remove(model);
                }
        }

    }
}