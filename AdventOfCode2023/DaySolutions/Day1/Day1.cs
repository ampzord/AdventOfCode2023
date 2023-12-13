using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day1;

public class Day1 : AdventOfCodeSolver
{
    private Dictionary<string, string> wordToNumber = new();
    public Day1(string day, string fileName) : base(day, fileName)
    {
        wordToNumber = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
    }

    public override void SolvePartOne()
    {
        int totalCalibration = 0;
        foreach (var line in InputData)
        {
            char leftDigit = ' ';
            char rightDigit = ' ';

            int startIndex = 0;
            int endIndex = line.Length - 1;
            bool foundLeftDigit = false;
            bool foundRightDigit = false;
            while (!foundLeftDigit || !foundRightDigit)
            {
                char currentLeftChar = line[startIndex];
                char currentRightChar = line[endIndex];

                if (!foundLeftDigit && char.IsDigit(currentLeftChar))
                {
                    leftDigit = currentLeftChar;
                    foundLeftDigit = true;
                }

                if (!foundRightDigit && char.IsDigit(currentRightChar))
                {
                    rightDigit = currentRightChar;
                    foundRightDigit = true;
                }

                if (foundLeftDigit && foundRightDigit)
                    break;

                startIndex++;
                endIndex--;
            }

            string digit = leftDigit.ToString() + rightDigit.ToString();
            totalCalibration += int.Parse(digit);
        }
        Console.WriteLine($"Total Calibration - Part One: {totalCalibration}");
    }

    readonly struct TextNumber 
    {
        public int FoundIndex { get; }
        public string Number { get; }

        public TextNumber(int foundIndex, string number)
        {
            FoundIndex = foundIndex;
            Number = number;
        }
    }

    private (TextNumber, TextNumber) GetTextNumber(string line)
    {
        TextNumber leftMostTextNumber = new TextNumber(int.MaxValue, "");
        TextNumber rightMostTextNumber = new TextNumber(-1, "");

        foreach (var kvp in wordToNumber)
        {
            string word = kvp.Key;
            int firstIndex = line.IndexOf(word);
            int lastIndex = line.LastIndexOf(word);

            if (firstIndex != -1 && firstIndex < leftMostTextNumber.FoundIndex)
            {
                leftMostTextNumber = new TextNumber(firstIndex, kvp.Value);
            }

            if (lastIndex != -1 && lastIndex > rightMostTextNumber.FoundIndex)
            {
                rightMostTextNumber = new TextNumber(lastIndex, kvp.Value);
            }
        }

        return (leftMostTextNumber, rightMostTextNumber);
    }

    public override void SolvePartTwo()
    {
        int totalCalibration = 0;
        foreach (var line in InputData)
        {
            var (leftMostTextNumber, rightMostTextNumber) = GetTextNumber(line);
            bool foundLeftWordDigit = leftMostTextNumber.FoundIndex != int.MaxValue;
            bool foundRightWordDigit = rightMostTextNumber.FoundIndex != -1;

            string leftDigit = leftMostTextNumber.Number;
            string rightDigit = rightMostTextNumber.Number;

            int startIndex = 0;
            int endIndex = line.Length - 1;
            bool foundLeftDigit = false;
            bool foundRightDigit = false;
            while (startIndex < line.Length)
            {
                char currentLeftChar = line[startIndex];
                char currentRightChar = line[endIndex];

                if (!foundLeftDigit && char.IsDigit(currentLeftChar))
                {
                    foundLeftDigit = true;

                    if (startIndex < leftMostTextNumber.FoundIndex)
                    {
                        leftDigit = currentLeftChar.ToString();
                    }
                }

                if (!foundRightDigit && char.IsDigit(currentRightChar))
                {
                    foundRightDigit = true;

                    if (endIndex > rightMostTextNumber.FoundIndex)
                    {
                        rightDigit = currentRightChar.ToString();
                    }
                }

                if (foundLeftDigit && foundRightDigit)
                    break;

                startIndex++;
                endIndex--;
            }

            string digit = leftDigit + rightDigit;
            totalCalibration += int.Parse(digit);
        }
        Console.WriteLine($"Total Calibration - Part Two: {totalCalibration}");
    }
}