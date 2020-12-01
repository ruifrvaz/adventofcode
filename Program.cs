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

            var answer = Day1.SolvePuzzle();

            Task.WaitAll(answer);
            Console.WriteLine($"The answer to Day 1 puzzle is: {answer.Result}.");
        }
    }
}
