using MvcAlexRodolfo.Models;
using MvcAlexRodolfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAlexRodolfo.Controllers
{
    public class NotebookController : BaseController<Notebook, NotebookDAO>
    {
        public NotebookController() : base(new NotebookDAO())
        {

        }
    }
}