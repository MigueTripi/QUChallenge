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
                    Code = 400,
                    Description = $"Request has null values"
                };
            }

            var matrixLenght = request.Matrix.Length;
            if (matrixLenght > 64)
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 400,
                    Description = $"Matrix has more rows than allowed. Current lenght: {matrixLenght}"
                };
            }

            var quantityColumns = request.Matrix[0].Length;
            if (request.Matrix.Any(x=> x.Length != quantityColumns))
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 400,
                    Description = $"Matrix has items with different quantity of columns"
                };
            }

            //64 could be configurated
            var maxColumnLength = 64;
            if (request.Matrix.Any(x => x.Length > maxColumnLength))
            {
                return new WordFinderRequestValidatorResult()
                {
                    IsOk = false,
                    Code = 400,
                    Description = $"Matrix has some item with more than {maxColumnLength} columns"
                };
            }

            return new WordFinderRequestValidatorResult()
            {
                IsOk = true,
                Code = 200,
                Description = $"OK"
            };
        }

    }
}
