using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QU.Challenge.API.Validators;
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

            var validatorResult = WordFinderValidator.ValidateRequest(request);
            if (!validatorResult.IsOk)
            {
                
            }
            
            var business = new WordFinder(request.Matrix);
            business.Find(request.Words);
            return new FindWordResponse();
        }

    }

}
