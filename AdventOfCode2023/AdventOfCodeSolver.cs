using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;

public abstract class AdventOfCodeSolver
{
    protected string InputData { get; }
    protected AdventOfCodeSolver(string day)
    {
        string filePath = Path.Combine("DaySolutions\\" + day, day + ".txt");
        InputData = File.ReadAllText(filePath);
    }

    public abstract void SolvePartOne();
    public abstract void SolvePartTwo();
}

