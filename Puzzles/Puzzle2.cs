using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles 
{
    public class Puzzle2 
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
                    var pattern = password.Split(':');
                    var quantities = pattern[0].Split('-');
                    var maxNumber = Regex.Replace(quantities[1], "[A-Za-z ]", "");
                    var letter = Regex.Replace(quantities[1], "[0-9 ]", "");
                    int freq = Regex.Matches(pattern[1], letter).Count;

                    if(freq >= Int32.Parse(quantities[0].Trim()) && freq <= Int32.Parse(maxNumber.Trim()))
                    {
                        numberOfValidPasswords++;
                    };
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
                    var pattern = passwordGroup.Split(':');
                    var quantities = pattern[0].Split('-');

                    var firstPosition = Int32.Parse(quantities[0].Trim()) - 1;
                    var lastPosition = Int32.Parse(Regex.Replace(quantities[1], "[A-Za-z ]", "")) - 1;
                    var letter = Regex.Replace(quantities[1], "[0-9 ]", "");
                    var password = pattern[1].Trim();

                    var letterAtFirstPosition = password.Substring(firstPosition, 1);
                    var letterAtLastPosition = password.Substring(lastPosition, 1);
                    int freq = Regex.Matches($"{letterAtLastPosition}{letterAtFirstPosition}", letter).Count;
                    if(freq == 1)
                    {
                        numberOfValidPasswords++;
                    };
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