using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers {
    public static class FileHelper 
    {
        public async static Task<List<string>> LoadPuzzleList(string filePath) {

            var puzzleList = new List<string>();

            using (var sr = new StreamReader(filePath))
            {
                while(sr.Peek() >= 0) 
                {

                    var puzzleEntry = await sr.ReadLineAsync();
                    puzzleList.Add(puzzleEntry);
                }
                return puzzleList;
            }
        }
    }
}