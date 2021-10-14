using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QU.Challenge.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QU.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordFinderController : ControllerBase
    {
        [HttpPost]
        [Route("find_words")]
        public FindWordResponse FindWords(FindWordRequest request)
        {
            //TODO: inject business instead of create it.
            var business = new FindRecursive();
            business.Execute(request.Matrix, request.Words);
            return new FindWordResponse();
        }

    }

}
