﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АИМВ_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferenceTable T1 = new DifferenceTable();
            T1.Step();
            T1.InitMatr();
            T1.FormDiffTable();
            T1.FillingMatrix();
            T1.DisplayMatr();
            T1.FinalTable();
            T1.Printf();
            Console.ReadKey();
        }
    }
}
