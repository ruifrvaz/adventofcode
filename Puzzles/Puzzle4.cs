using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.Puzzles 
{
    public class Puzzle4
    {
        private static string FILEPATH = "Files/puzzlelist4.txt";

        public async static Task<int> SolveFirstPartOfPuzzle()
        {
            try
            {
                var passportEntries = await FileHelper.LoadPuzzleList(FILEPATH);
                var validPassports = 0;
                var passportLine = string.Empty;
                foreach (var passportEntry in passportEntries)
                {
                    passportLine = passportLine+" "+passportEntry;
                    if(string.IsNullOrEmpty(passportEntry))
                    {
                        var passport = CreatePassport(passportLine);
                        if(passport.IsValid()) 
                        {
                            validPassports++;
                        }
                        passportLine = string.Empty;
                    }

                }
                return validPassports;
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
                var validPassports = 0;
                var passportLine = string.Empty;
                foreach (var passportEntry in passportEntries)
                {
                    passportLine = passportLine+" "+passportEntry;
                    if(string.IsNullOrEmpty(passportEntry))
                    {
                        var passport = CreatePassport(passportLine);
                        if(passport.IsValid()) 
                        {
                            validPassports++;
                        }
                        passportLine = string.Empty;
                    }

                }
                return validPassports;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Unable to solve puzzle: {ex}.");
            }
            
            return -1;
        }

        private static Passport CreatePassport(string passportLine)
        {
            var passport = new Passport();
            var passportFields = passportLine.Trim().ToLowerInvariant().Split(" ");
            foreach (var field in passportFields)
            {
                var fieldName = field.Split(":")[0];
                var fieldValue = field.Split(":")[1];
                var orientation = fieldName switch
                {
                    nameof(passport.pid)  => passport.pid = fieldValue,
                    nameof(passport.cid)  => passport.cid = fieldValue,
                    nameof(passport.ecl)  => passport.ecl = fieldValue,
                    nameof(passport.eyr)  => passport.eyr = fieldValue,
                    nameof(passport.hcl)  => passport.hcl = fieldValue,
                    nameof(passport.hgt)  => passport.hgt = fieldValue,
                    nameof(passport.iyr)  => passport.iyr = fieldValue,
                    nameof(passport.byr)  => passport.byr = fieldValue,
                    _                     => ""
                };
            }
            return passport;
        }
    }

    public class Passport 
    {
        // byr (Birth Year) - four digits; at least 1920 and at most 2002.
        public bool byrIsValid => Int32.TryParse(this.byr, out _) && Int32.Parse(this.byr) >= 1920 && Int32.Parse(this.byr) <= 2002;
        
        // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
        public bool iyrIsValid => Int32.TryParse(this.iyr, out _) && Int32.Parse(this.iyr) >= 2010 && Int32.Parse(this.iyr) <= 2020;
        
        // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
        public bool eyrIsValid => Int32.TryParse(this.eyr, out _) && Int32.Parse(this.eyr) >= 2020 && Int32.Parse(this.eyr) <= 2030;

        // hgt (Height) - a number followed by either cm or in: If cm, the number must be at least 150 and at most 193. 
        // If in, the number must be at least 59 and at most 76.
        public bool hgtIsValid => Regex.IsMatch(this.hgt, "(^1([5-8][0-9]|9[0-3])cm$)|(^(59|6[0-9]|7[0-6])in$)");

        //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        public bool hclIsValid => Regex.IsMatch(this.hcl, "^#([a-f0-9]{6})$");

        //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        public bool eclIsValid => Regex.IsMatch(this.ecl, "amb|blu|brn|gry|grn|hzl|oth");

        //pid (Passport ID) - a nine-digit number, including leading zeroes.
        public bool pidIsValid => Regex.IsMatch(this.pid, "[0-9]{9}");


        // pid (Passport ID)
        public string pid {get;set;}

        // iyr (Issue Year)
        public string iyr {get;set;}

        // eyr (Expiration Year)
        public string eyr {get;set;}

        // cid (Country ID)
        public string cid {get;set;}

        // hgt (Height)
        public string hgt {get;set;}

        // byr (Birth Year)
        public string byr {get;set;}

        // hcl (Hair Color)
        public string hcl {get;set;}

        // ecl (Eye Color)
        public string ecl {get;set;}

        internal bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.ecl) && eclIsValid
            && !string.IsNullOrWhiteSpace(this.eyr) && eyrIsValid
            && !string.IsNullOrWhiteSpace(this.hcl) && hclIsValid
            && !string.IsNullOrWhiteSpace(this.hgt) && hgtIsValid
            && !string.IsNullOrWhiteSpace(this.iyr) && iyrIsValid
            && !string.IsNullOrWhiteSpace(this.pid) && pidIsValid
            && !string.IsNullOrWhiteSpace(this.byr) && byrIsValid;
        }
    }
}