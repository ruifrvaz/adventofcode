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

            // Day 1
            var answerDay1Part1 = Puzzle1.SolveFirstPartOfPuzzle();
            var answerDay1Part2 = Puzzle1.SolveSecondPartOfPuzzle();

            // Day 2
            var answerDay2Part1 = Puzzle2.SolveFirstPartOfPuzzle();
            var answerDay2Part2 = Puzzle2.SolveSecondPartOfPuzzle();

            // Day 3
            var answerDay3Part1 = Puzzle3.SolveFirstPartOfPuzzle();
            var answerDay3Part2 = Puzzle3.SolveSecondPartOfPuzzle();

            // Day 4
            var answerDay4Part1 = Puzzle4.SolveFirstPartOfPuzzle();
            var answerDay4Part2 = Puzzle4.SolveSecondPartOfPuzzle();

            Task.WaitAll(answerDay1Part1, answerDay1Part2, answerDay2Part1);

            Console.WriteLine($"The answer to Day 1 part 1 puzzle is: {answerDay1Part1.Result}.");
            Console.WriteLine($"The answer to Day 1 part 2 puzzle is: {answerDay1Part2.Result}.");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"The answer to Day 2 part 1 puzzle is: {answerDay2Part1.Result}.");
            Console.WriteLine($"The answer to Day 2 part 2 puzzle is: {answerDay2Part2.Result}.");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"The answer to Day 3 part 1 puzzle is: {answerDay3Part1.Result}.");
            Console.WriteLine($"The answer to Day 3 part 2 puzzle is: {answerDay3Part2.Result}.");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"The answer to Day 4 part 1 puzzle is: {answerDay4Part1.Result}.");
            Console.WriteLine($"The answer to Day 4 part 2 puzzle is: {answerDay4Part2.Result}.");
        }
    }
}
