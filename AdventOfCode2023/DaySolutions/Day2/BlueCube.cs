using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day2;
internal class BlueCube : ICube
{
    public int Quantity { get; }
    public int MaxQuantity { get; } = 14;
    public BlueCube(int quantity)
    {
        Quantity = quantity;
    }

    public bool isPossible()
    {
        return Quantity <= MaxQuantity;
    }
}

