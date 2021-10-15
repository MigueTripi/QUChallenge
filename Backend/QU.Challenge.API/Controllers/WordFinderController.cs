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
        public async Task<IActionResult> FindWords(FindWordRequest request)
        {

            var validatorResult = WordFinderValidator.ValidateRequest(request);
            if (!validatorResult.IsOk)
            {
                return StatusCode(validatorResult.Code, validatorResult.Description);
            }

            var business = new WordFinder(request.Matrix);
            return Ok(business.Find(request.Words));
        }

    }

}
