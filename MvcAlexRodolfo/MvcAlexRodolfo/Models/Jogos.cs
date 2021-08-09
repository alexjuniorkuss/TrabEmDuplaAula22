using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Models
{
    public  class Jogos : BaseModel
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int FaixaEtaria { get; set; }
    }
}