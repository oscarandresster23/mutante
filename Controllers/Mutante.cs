using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Mutante.Funciones;
using Mutante.Modelos;


namespace Mutante.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class Mutante : ControllerBase
    {

        [HttpPost]
        [Route("/")]
        public HttpResponseMessage Mutant([FromBody] adnRequest dna)
        {
            dnaUtils dnaClass = new dnaUtils();
            string[] dnaIn = dna.dna;
            if (dnaClass.isDnaValid(dnaIn))
            {
                if (dnaClass.isMutant(dnaIn))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}
