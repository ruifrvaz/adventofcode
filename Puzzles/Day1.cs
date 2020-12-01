
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles {
    public static class Day1 
    {
        private static string FILEPATH = "Files/ExpenseList.txt";
        public async static Task<string> SolvePuzzle()
        {
            try
            {
                var expenseList = await FileHelper.LoadExpenseFile(FILEPATH);
                (int value1, int value2) = FindValuesWhoseSumIs2020(expenseList);
                return (value1*value2).ToString();
            } 
            catch(Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
                
            }
            return "404";
        }

        ///
        // Find the values recursively by iterating the list and emptying it 1 element at a time. 
        ///
        private static (int, int) FindValuesWhoseSumIs2020(List<int> expenseList) 
        {
            var value1 = expenseList[0];
            var shorterList = new List<int>(expenseList);
            shorterList.RemoveAt(0);
            foreach (var expense in shorterList)
            {
                if(value1 + expense == 2020) 
                {
                    return (value1, expense);
                }    
            }

            return FindValuesWhoseSumIs2020(shorterList);
        }
    }
}