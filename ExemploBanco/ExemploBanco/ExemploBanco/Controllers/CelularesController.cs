using ExemploBanco.Models;
using ExemploBanco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploBanco.Controllers
{
    public class CelularesController : BaseController<Celular, CelularRepository>
    {
        public CelularesController() : base(new CelularRepository())
        {

        }
    }
}