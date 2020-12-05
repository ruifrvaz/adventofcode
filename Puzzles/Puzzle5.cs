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
                var highestId = 0;

                var boardingPasses = await FileHelper.LoadPuzzleList(FILEPATH);
                foreach (var boardingPass in boardingPasses)
                {
                    var seat = FindSeat(boardingPass);
                    var id = CalculateSeatId(seat);
                    if(id > highestId)
                    {
                        highestId = id;
                    }
                }
                return highestId;
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


        private static Seat FindSeat(string boardingPass)
        {
            var seat = new Seat
            {
                Column = BinaryFind(boardingPass.Substring(0,5)),
                Row    = BinaryFind(boardingPass.Substring(4,3))
            };

            return seat;
        }

        private static int BinaryFind(string v)
        {
            throw new NotImplementedException();
        }

        private static int CalculateSeatId(Seat seat)
        {
            return seat.Row*8 + seat.Column;
        }

    }

    public class Seat 
    {
        public int Row { get; set; }
        public int Column { get; set; } 
    }
}