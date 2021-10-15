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

        //Returning IEnumerable could have some performance issues in case the caller transform this into a concrete list (or array) several times 
        public IEnumerable<string> Find(string[] words)
        {
            FindWords(words);
            //Quantity could be stored in a settings.
            //I'm ordering alphabetically only for testing purposes.
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
                    var currentCharacter = Matrix[x][y];
                    var wordsMatchingFirstCharacter = words.Where(w => w[0] == currentCharacter).Distinct().ToList();
                    
                    if (wordsMatchingFirstCharacter.Any())
                    {
                        //Try to find in horizontal way
                        RecursiveSearch(
                            Matrix[x], 
                            wordsMatchingFirstCharacter, 
                            y + 1, 
                            1, 
                            currentCharacter.ToString());

                        //Try to find in vertical way
                        string column = "";
                        for (int i = x; i < Matrix.Length; i++)
                        {
                            column += Matrix[i][y];
                        }
                        RecursiveSearch(
                            column,
                            wordsMatchingFirstCharacter,
                            1,
                            1,
                            currentCharacter.ToString());

                    }
                }
            }
        }

        private void RecursiveSearch(string row, List<string> words, int arrayIndex, int wordIndex, string collectedCharacters)
        {
            //Check if the row contains given words
            var matchingWords = words.Where(x => 
                x.Length - 1 >= wordIndex &&
                row.Length - 1 >= arrayIndex &&
                x[wordIndex] == row[arrayIndex]).ToList();
            
            //In case of match is absent we leave the execution.
            if (!matchingWords.Any())
            {
                words.ForEach(w => Console.WriteLine("NO Matching words. " + row + " " + w));
                return;
            }
            collectedCharacters += row[arrayIndex].ToString();

            //I look for the not completed words 
            var pendingWords = matchingWords.Where(x => x != collectedCharacters).ToList();
            
            //if we have different quantity of word is because we found a matching word
            if (pendingWords.Count() < matchingWords.Count())
            {
                Console.WriteLine("FOUND : " + collectedCharacters);
                if (!Result.ContainsKey(collectedCharacters))
                    Result.Add(collectedCharacters, 0);

                Result[collectedCharacters] += 1;
            }

            if (pendingWords.Count() > 0)
            {
                RecursiveSearch(row, pendingWords.ToList(), arrayIndex +1, wordIndex + 1, collectedCharacters);
            }
        }
    }
}
