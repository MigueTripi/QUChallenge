using System.Collections.Generic;
using System.Linq;

namespace QU.Challenge.API.Controllers
{
    public class FindWordResponse
    {
        private string[] Words;

        public FindWordResponse(IEnumerable<string> words)
        {
            this.Words = words.ToArray();
        }
    }
}