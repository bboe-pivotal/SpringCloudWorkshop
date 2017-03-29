using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace ColorService.Controllers
{
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {
        // GET: api/colors
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "blue" };
        }
    }
}
