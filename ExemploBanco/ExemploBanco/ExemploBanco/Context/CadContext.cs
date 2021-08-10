using ExemploBanco.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExemploBanco.Context
{
    public class CadContext : DbContext
    {
        public DbSet<Celular> Celular { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public CadContext():base("CadContext")
        {

        }   
    }
}