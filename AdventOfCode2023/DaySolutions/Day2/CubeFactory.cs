using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day2;
public static class CubeFactory
{
    public static ICube CreateCube(string color, int quantity)
    {
        switch (color.ToLower())
        {
            case "red":
                return new RedCube(quantity);
            case "green":
                return new GreenCube(quantity);
            case "blue":
                return new BlueCube(quantity);
            default:
                throw new Exception("Unknown color for cube.");
        }
    }
}

