using System.Collections.Generic;

namespace QU.Challenge.Business
{

    public class Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            var matrix = new string[]
            {
                "BOA"
            };

            var words = new string[]
            {
                "BOAT",
            };
            //new FindRecursive().Execute(null, null);
            new WordFinder(matrix).Find(words);

        }
    }
}
