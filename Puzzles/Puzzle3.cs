using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles 
{
    public class Puzzle3
    {
        private static string FILEPATH = "Files/puzzlelist2.txt";

        public async static Task<int> SolveFirstPartOfPuzzle()
        {
            var numberOfValidPasswords = 0;
            try
            {
                var passwordList = await FileHelper.LoadPuzzleList(FILEPATH);
                foreach (var password in passwordList)
                {
                   
                }
                
                return numberOfValidPasswords;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        public async static Task<int> SolveSecondPartOfPuzzle()
        {
            var numberOfValidPasswords = 0;
            try
            {
                var passwordList = await FileHelper.LoadPuzzleList(FILEPATH);
                foreach (var passwordGroup in passwordList)
                {
                   
                }
                
                return numberOfValidPasswords;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }
    }
}