using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles 
{
    public class Puzzle5
    {
        private static string FILEPATH = "Files/puzzlelist5.txt";

        public async static Task<int> SolveFirstPartOfPuzzle()
        {
            try
            {
                var passportEntries = await FileHelper.LoadPuzzleList(FILEPATH);
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        public async static Task<int> SolveSecondPartOfPuzzle()
        {
            try
            {
                var passportEntries = await FileHelper.LoadPuzzleList(FILEPATH);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }
    }
}