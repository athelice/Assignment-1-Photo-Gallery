using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")] // path to get to this API
    [ApiController]
    
    public class PicController : ControllerBase

    {
        private readonly IHostingEnvironment _env; // for every injected variable, corresponding global variable is created
        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpGet("{id}")]
        public IActionResult GetImage(int id)
        {
            var webRoot = _env.WebRootPath; // go to the root folder
            // get the path
            var path = Path.Combine(webRoot + "/Pics/", "Ring" + id + ".jpg");
            // read the image and store in binary file which is in buffer
            var Buffer = System.IO.File.ReadAllBytes(path); // get the path, read the file and create a binary; read binary of the file and save it in the buffer 
            // using the bufferr , create a file and return the image
            return File(Buffer, "image/jpeg");

           }
    }
}