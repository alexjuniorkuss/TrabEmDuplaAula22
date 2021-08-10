using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploBanco.Models
{
    public class Jogos : BaseModel
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}