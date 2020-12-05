using System;
using System.Collections.Generic;
using System.Linq;
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
                    seat.Id = CalculateSeatId(seat);
                    if(seat.Id > highestId)
                    {
                        highestId = seat.Id;
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
                var seats = new List<Seat>();
                var passportEntries = await FileHelper.LoadPuzzleList(FILEPATH);
                foreach (var passportEntry in passportEntries)
                {
                    var seat = FindSeat(passportEntry);
                    seat.Id = CalculateSeatId(seat); 
                    seats.Add(seat);
                }
                seats = seats.OrderBy(s => s.Id).ToList();
                return FindMySeatId(seats);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        private static int FindMySeatId(List<Seat> seats)
        {
            var previousId = seats[0].Id;
            for(int i = 1; i < seats.Count; i++)
            {
                if(previousId + 1 != seats[i].Id)
                {
                    return previousId + 1;
                }
                previousId = seats[i].Id;
            }
            return -1;
        }

        private static Seat FindSeat(string boardingPass)
        {
            boardingPass = boardingPass.ToLowerInvariant();
            var seat = new Seat
            {
                Row       = BinaryFind(boardingPass.Substring(0,7), 0, 127),
                Column    = BinaryFind(boardingPass.Substring(7,3), 0, 7)
            };

            return seat;
        }

        private static int BinaryFind(string v, int lower, int higher)
        {
            if(v.Length == 1)
            {
                return v.Equals("f") || v.Equals("l") ? lower : higher;
            }
            var firstLetter = v.Substring(0,1);
            var half = (int)Math.Round((higher - lower) / 2.0);
            if(firstLetter.Equals("f") || firstLetter.Equals("l"))
            {
                return BinaryFind(v.Substring(1, v.Length -1), lower, higher - half);
            }
            
            return BinaryFind(v.Substring(1, v.Length -1), lower + half, higher);
        }

        private static int CalculateSeatId(Seat seat)
        {
            return seat.Row * 8 + seat.Column;
        }

    }

    public class Seat 
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; } 
    }
}