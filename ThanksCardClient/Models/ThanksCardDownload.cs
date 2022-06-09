using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ThanksCardClient.Models
{
    public class ThanksCardDownload : Controller
    {
        public ActionResult cardDownload(byte[] vs)
        {
            return File(vs, "%USERPROFILE%/Desktop", "test.txt");
        }
    }
}

