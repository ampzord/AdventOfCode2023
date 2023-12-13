using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day2;

public interface ICube
{
    public int Quantity { get; }
    public int MaxQuantity { get; }

    public bool isPossible();
}

