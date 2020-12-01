using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers {
    public static class FileHelper 
    {
        public async static Task<List<int>> LoadExpenseFile(string filePath) {

            var expenseList = new List<int>();

            using (var sr = new StreamReader(filePath))
            {
                while(sr.Peek() >= 0) 
                {

                    var expense = await sr.ReadLineAsync();
                    expenseList.Add(Int32.Parse(expense));
                }
                return expenseList;
            }
        }
    }
}