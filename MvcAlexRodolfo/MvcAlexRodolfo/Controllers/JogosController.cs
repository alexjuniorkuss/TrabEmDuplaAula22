using MvcAlexRodolfo.Models;
using MvcAlexRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Controllers
{
    public class JogosController : BaseController<Jogos, JogosDAO>
    {
        public JogosController():base(new JogosDAO())
        {

        }
    }
}