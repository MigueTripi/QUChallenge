using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QU.Challenge.Business
{
    public class WordFinder
    {

        private Dictionary<string, int> Result = new Dictionary<string, int>();
        private string[] Matrix;

        //Returning IEnumerable could have some performance issues in case the caller transforms this into a concrete list (or array) several times 
        public IEnumerable<string> Find(IEnumerable<string> words)
        {
            FindWords(words);
            //Quantity could be stored in a settings.
            //I'm ordering alphabetically only for unit testing purposes.
            return Result.OrderByDescending(x => x.Value)
                .ThenBy(x=> x.Key)
                .Take(10)
                .Select(x => x.Key);
        }

        public WordFinder(IEnumerable<string> matrix)
        {
            Matrix = matrix.ToArray();
        }

        private void FindWords(IEnumerable<string> words)
        {
            for (int x = 0; x < Matrix.Length; x++)
            { 
                for (int y = 0; y < Matrix[x].Length; y++)
                {
                    //Look for words which ones match the first letter within the current position of the matrix
                    var currentCharacter = Matrix[x][y];
                    var wordsMatchingFirstCharacter = words.Where(w => w[0] == currentCharacter).Distinct().ToList();
                    
                    if (wordsMatchingFirstCharacter.Any())
                    {
                        //Find in horizontal way
                        RecursiveSearch(
                            GetNextCoordinates((X: x, Y: y), true),
                            wordsMatchingFirstCharacter,
                            1,
                            currentCharacter.ToString(),
                            true);

                        //Find in vertical way
                        RecursiveSearch(
                            GetNextCoordinates((X: x, Y: y), false),
                            wordsMatchingFirstCharacter,
                            1,
                            currentCharacter.ToString(),
                            false);

                    }
                }
            }
        }


        private void RecursiveSearch(
            (int X, int Y) coordinates,
            List<string> words,
            int wordIndex,
            string collectedCharacters,
            bool horizontalSearch)
        {
            //Check if current letter in the collection of words matches in the matrix's place
            //Note that for horizontal or vertical finding I change the valid condition
            var matchingWords = words.Where(x =>
                x.Length - 1 >= wordIndex &&
                (
                    (horizontalSearch && Matrix[0].Length - 1 >= coordinates.Y) ||
                    (!horizontalSearch && Matrix.Length - 1 >= coordinates.X) 
                ) &&
                x[wordIndex] == Matrix[coordinates.X][coordinates.Y]).ToArray();
            
            //In case of match is absent we leave the execution.
            if (!matchingWords.Any())
            {
                //Only for testing propose
                //words.ForEach(w => Console.WriteLine("NO Matching words. " + w));
                
                return;
            }

            //I have a match here and I store it in the collected characters
            collectedCharacters += Matrix[coordinates.X][coordinates.Y];

            //I look for the not completed words 
            var pendingWords = matchingWords.Where(x => x != collectedCharacters).ToArray();

            //if we have different quantity of word is because we found a matching word
            if (pendingWords.Length < matchingWords.Length)
            {
                //Console.WriteLine("FOUND : " + collectedCharacters);
                if (!Result.ContainsKey(collectedCharacters))
                    Result.Add(collectedCharacters, 0);

                Result[collectedCharacters] += 1;
            }

            if (pendingWords.Length > 0)
            {
                RecursiveSearch(
                    GetNextCoordinates(coordinates, horizontalSearch),
                    pendingWords.ToList(), 
                    wordIndex + 1, 
                    collectedCharacters,
                    horizontalSearch);
            }
        }

        private (int X, int Y) GetNextCoordinates((int X, int Y) coordinates, bool horizontalSearch)
        {
            return horizontalSearch ? (coordinates.X, Y: coordinates.Y + 1) : (X: coordinates.X + 1, coordinates.Y);
        }
    }
}
