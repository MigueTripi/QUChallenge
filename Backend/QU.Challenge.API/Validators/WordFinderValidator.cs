using QU.Challenge.API.Controllers;
using System.Linq;

namespace QU.Challenge.API.Validators
{        
    public static class WordFinderValidator
    {
        public static WordFinderRequestValidatorResult ValidateRequest(FindWordRequest request)
        {
            
            if(request == null || request.Matrix == null || request.Words == null)
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 1,
                    Description = "Request has null values"
                };
            }

            var matrixLenght = request.Matrix.Length;
            if (matrixLenght > 64)
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 2,
                    Description = $"Matrix has more rows than allowed. Current lenght: {matrixLenght}"
                };
            }

            var quantityColumns = request.Matrix[0].Length;
            if (!request.Matrix.Any(x=> x.Length != quantityColumns)
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 3,
                    Description = $"Matrix has items with different quantity of columns"
                };
            }

            return new WordFinderRequestValidatorResult()
            {
                IsOk = true,
                Code = 0,
                Description = $"OK"
            };
        }

    }
}
