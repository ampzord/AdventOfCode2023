using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Utilities;
public static class PuzzleUtils
{
    public static string GetFilePath(string filename)
    {
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        return Directory.GetCurrentDirectory(); ;
    }
}
