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

            var answerDay1Part1 = Puzzle1.SolveFirstPartOfPuzzle();
            var answerDay1Part2 = Puzzle1.SolveSecondPartOfPuzzle();

            var answerDay2Part1 = Puzzle2.SolveFirstPartOfPuzzle();
            var answerDay2Part2 = Puzzle2.SolveSecondPartOfPuzzle();

            Task.WaitAll(answerDay1Part1, answerDay1Part2, answerDay2Part1);

            Console.WriteLine($"The answer to Day 1 part 1 puzzle is: {answerDay1Part1.Result}.");
            Console.WriteLine($"The answer to Day 1 part 2 puzzle is: {answerDay1Part2.Result}.");
            Console.WriteLine($"The answer to Day 1 part 2 puzzle is: {answerDay2Part1.Result}.");
            Console.WriteLine($"The answer to Day 1 part 2 puzzle is: {answerDay2Part2.Result}.");
        }
    }
}
