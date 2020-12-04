using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles 
{
    public class Puzzle3
    {
        private static string FILEPATH = "Files/puzzlelist3.txt";

        public async static Task<int> SolveFirstPartOfPuzzle()
        {
            try
            {
                var itineraries = await FileHelper.LoadPuzzleList(FILEPATH);
                var slope = 3;
                return CountNumberOfTrees(slope, 1, itineraries);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        public async static Task<int> SolveSecondPartOfPuzzle()
        {
            var itineraries = await FileHelper.LoadPuzzleList(FILEPATH);
            try
            {
                //Right 1, down 1.
                var numberOfTrees11 = CountNumberOfTrees(1, 1, itineraries);
                //Right 3, down 1. (This is the slope you already checked.)
                var numberOfTrees31 = CountNumberOfTrees(3, 1, itineraries);
                //Right 5, down 1.
                var numberOfTrees51 = CountNumberOfTrees(5, 1, itineraries);
                //Right 7, down 1.
                var numberOfTrees71 = CountNumberOfTrees(7, 1, itineraries);
                //Right 1, down 2.
                var numberOfTrees12 = CountNumberOfTrees(1, 2, itineraries);

                return numberOfTrees11*numberOfTrees31*numberOfTrees51*numberOfTrees71*numberOfTrees12;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        private static int CountNumberOfTrees(int slope, int depth, List<string> itineraries) 
        {
            var numberOfTrees = 0;
                var slopeCounter = slope;
                
                for(int i = depth; i < itineraries.Count; i+=depth)
                {
                    if(slopeCounter >= itineraries[i].Length)
                    {
                        slopeCounter = slopeCounter - itineraries[i].Length;
                    }

                    var isTree = CheckForTree(itineraries[i], slopeCounter);
                    if(isTree)
                    {
                        numberOfTrees++;
                    }
                    slopeCounter = slopeCounter+slope;
                }
                return numberOfTrees;
        }
        
        public static bool CheckForTree(string itinerary, int slope)
        {
            var trajectory = itinerary.Substring(slope, 1);
            return trajectory.Equals("#");
        }
    }
}