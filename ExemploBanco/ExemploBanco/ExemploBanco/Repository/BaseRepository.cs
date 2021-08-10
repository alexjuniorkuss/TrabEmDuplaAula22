using ExemploBanco.Context;
using ExemploBanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExemploBanco.Repository
{
    public class BaseRepository<T> where T:BaseModel
    { 
        public void Create(T model)
        {
            using (var context = new CadContext())
            {
                context.Entry<T>(model).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<T> Read()
        {
            List<T> lista = new List<T>();
            using (var context = new CadContext())
            {
                lista = context.Set<T>().ToList();
            }
            return lista;
        }
        public T Read(int id)
        {
            T model = Activator.CreateInstance<T>();
            using (var context = new CadContext())
            {
                model = context.Set<T>().Find(id);
            }
            return model;
        }
        public void Update(T model)
        {
            using (var context = new CadContext())
            {
                context.Entry<T>(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            T model = this.Read(id);
            using (var context = new CadContext())
            {
                context.Entry<T>(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Delete(T model)
        {
            using (var context = new CadContext())
            {
                context.Entry<T>(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}