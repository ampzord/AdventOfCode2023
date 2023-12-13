using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.DaySolutions.Day2;
internal class RedCube : ICube
{
    public int Quantity { get; }
    public int MaxQuantity { get; } = 12;
    public RedCube(int quantity)
    {
        Quantity = quantity;
    }

    public bool isPossible()
    {
        return Quantity <= MaxQuantity;
    }
}

