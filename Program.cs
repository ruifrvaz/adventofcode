using System;
using System.Threading.Tasks;
using AdventOfCode.Puzzles;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Advent Of Code challenge!");
            Console.WriteLine("<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>");

            var answerDay1Part1 = Day1.SolveFirstPartOfPuzzle();
            var answerDay1Part2 = Day1.SolveSecondPartOfPuzzle();

            Task.WaitAll(answerDay1Part1, answerDay1Part2);

            Console.WriteLine($"The answer to Day 1 part 1 puzzle is: {answerDay1Part1.Result}.");
            Console.WriteLine($"The answer to Day 1 part 2 puzzle is: {answerDay1Part2.Result}.");
        }
    }
}
