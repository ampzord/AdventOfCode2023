using AdventOfCode2023.DaySolutions.Day2;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day1;

public class Day2 : AdventOfCodeSolver
{
    public Day2(string day, string fileName) : base(day, fileName) { }

    public override void SolvePartOne()
    {
        int totalSum = 0;
        foreach (var line in InputData)
        {
            bool impossibleGame = false;
            var splitInput = line.Split(':', ';');
            int gameIndex = GetGameIndex(splitInput[0]);
            if (gameIndex == -1)
            {
                throw new Exception($"Game index not found or invalid: {splitInput[0]}");
            }

            var setGames = splitInput.Skip(1).ToArray();

            var cubes = new List<ICube>();
            for (int i = 0; i < setGames.Length; i++)
            {
                var splitSet = setGames[i].Split(',');
                for (int j = 0; j < splitSet.Length; j++)
                {
                    string[] set = splitSet[j].Split(' ').Skip(1).ToArray();
                    if (!CubeFactory.CreateCube(set[1], int.Parse(set[0])).isPossible())
                    {
                        impossibleGame = true;
                        break;
                    }
                }

                if (impossibleGame)
                    break;
            }

            if (!impossibleGame)
            {
                totalSum += gameIndex;
            }
        }
        Console.WriteLine($"Total Sum of Possible IDs - Part One: {totalSum}");
    }

    private int GetGameIndex(string input)
    {
        string[] parts = input.Split(' ');

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int result))
            {
                return result;
            }
        }

        return -1;
    }

    private (int, int, int) GetLeastCubesQuantity(List<ICube> cubes)
    {
        int leastRedCube = 0;
        int leastGreenCube = 0;
        int leastBlueCube = 0;
        foreach(var cube in cubes)
        {
            if (cube is RedCube)
            {
                if (leastRedCube < cube.Quantity)
                    leastRedCube = cube.Quantity;
            }
            else if (cube is GreenCube)
            {
                if (leastGreenCube < cube.Quantity)
                    leastGreenCube = cube.Quantity;
            }
            else
            {
                if (leastBlueCube < cube.Quantity)
                    leastBlueCube = cube.Quantity;
            }
        }

        return (leastRedCube, leastGreenCube, leastBlueCube);
    }
    
    public override void SolvePartTwo()
    {
        int totalSum = 0;
        foreach (var line in InputData)
        {
            var splitInput = line.Split(':', ';');
            int gameIndex = GetGameIndex(splitInput[0]);
            if (gameIndex == -1)
            {
                throw new Exception($"Game index not found or invalid: {splitInput[0]}");
            }

            var setGames = splitInput.Skip(1).ToArray();

            var cubes = new List<ICube>();
            for (int i = 0; i < setGames.Length; i++)
            {
                var splitSet = setGames[i].Split(',');
                for (int j = 0; j < splitSet.Length; j++)
                {
                    string[] set = splitSet[j].Split(' ').Skip(1).ToArray();
                    cubes.Add(CubeFactory.CreateCube(set[1], int.Parse(set[0])));
                }
            }

            var (leastRedCube, leastGreenCube, leastBlueCube) = GetLeastCubesQuantity(cubes);
            totalSum += (leastRedCube * leastGreenCube * leastBlueCube);
        }
        Console.WriteLine($"Total Sum of Least Cubes - Part Two: {totalSum}");
    }
}