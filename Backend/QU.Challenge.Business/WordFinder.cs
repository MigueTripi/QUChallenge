using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QU.Challenge.Business
{
    public class WordFinder
    {

        private List<string> Result = new List<string>();
        private string[] Matrix;
        public List<string> Find(string[] words)
        {
            FindWords(words);
            Result.ForEach(r => Console.WriteLine("FOUND: " + r));
            return Result;
        }

        public WordFinder(IEnumerable<string> matrix)
        {
            Matrix = matrix.ToArray();
        }

        private void FindWords(IEnumerable<string> words)
        {
            for (int x = 0; x < Matrix.Count(); x++)
            { 
                for (int y = 0; y < Matrix[x].Length; y++)
                {
                    var currentCharacter = Matrix[x][y];
                    var wordsMatchingFirstCharacter = words.Where(w => w[0] == currentCharacter).Distinct().ToList();
                    if (wordsMatchingFirstCharacter.Any())
                    {
                        RecursiveSearch(Matrix[x], wordsMatchingFirstCharacter, y+1, 1, currentCharacter.ToString());
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
                Result.Add(collectedCharacters);
            }

            if (pendingWords.Count() > 0)
            {
                RecursiveSearch(row, pendingWords.ToList(), arrayIndex +1, wordIndex + 1, collectedCharacters);
            }
            //var matchingWords = words.Where(x => x.Length - 1 >= currentIndex && x[currentIndex] == row[currentIndex]);
            //if (!matchingWords.Any())
            //{
            //    Console.WriteLine("NO Matching words. " + row + " " + words[currentIndex]);
            //    return;
            //}


            //if (matchingWords.Where(x=> ).Count() > 0)
            //{

            //}
        }
    }
}
