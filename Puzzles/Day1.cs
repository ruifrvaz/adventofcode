
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles {
    public static class Day1 
    {
        private static string FILEPATH = "Files/expenselist.txt";

        private static List<ValueList> CombinedValuesFound = new List<ValueList>();
        public async static Task<string> SolveFirstPartOfPuzzle()
        {
            try
            {
                var expenseList = await FileHelper.LoadExpenseFile(FILEPATH);
                (int value1, int value2) = FindTwoValuesWhoseSumIs2020(expenseList);
                return (value1*value2).ToString();
            } 
            catch(Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
                
            }
            return "404";
        }

        public async static Task<string> SolveSecondPartOfPuzzle()
        {
            try
            {
                var expenseList = await FileHelper.LoadExpenseFile(FILEPATH);
                (int value1, int value2, int value3) = FindThreeValuesWhoseSumIs2020(expenseList);
                return (value1*value2*value3).ToString();
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
        private static (int, int) FindTwoValuesWhoseSumIs2020(List<int> expenseList) 
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

            return FindTwoValuesWhoseSumIs2020(shorterList);
        }

        ///
        // Find the values recursively by iterating the list and emptying it 1 element at a time. 
        ///
        private static (int, int, int) FindThreeValuesWhoseSumIs2020(List<int> expenseList) 
        {
            var outcome = FindAllCombinationsWhoseSumIsLessThan2020(expenseList);
            foreach (var expense in expenseList)
            {
                foreach (var valueList in CombinedValuesFound)
                {
                    Console.WriteLine($"{valueList.Value1}+{valueList.Value2}+{expense} = {valueList.Value1+valueList.Value2+expense}.");
                    if(valueList.Value1 + valueList.Value2 + expense == 2020) 
                    {
                        return (valueList.Value1, valueList.Value2, expense);
                    }
                }  
            }
            return (0,0,0);
        }

        ///
        // Find the values recursively by iterating the list and emptying it 1 element at a time. 
        ///
        private static int FindAllCombinationsWhoseSumIsLessThan2020(List<int> expenseList) 
        {
            if(expenseList.Count == 0) 
            {
                return 1;
            }
            var value1 = expenseList[0];
            var shorterList = new List<int>(expenseList);
            shorterList.RemoveAt(0);
            foreach (var expense in shorterList)
            {
                if(value1 + expense <= 2020) 
                {
                    CombinedValuesFound.Add(new ValueList{ Value1 = value1, Value2 = expense});
                }    
            }

            return FindAllCombinationsWhoseSumIsLessThan2020(shorterList);
        }
    }

    public class ValueList 
    {
        public int Value1 {get;set;}
        public int Value2 {get;set;}
    }
}