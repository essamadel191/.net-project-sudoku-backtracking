using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid_to_solve ={         {0,0,0,3,0,0,2,0,0},
                                            {0,0,0,0,0,8,0,0,0},
                                            {0,7,8,0,6,0,3,4,0},

                                            {0,4,2,5,1,0,0,0,0},
                                            {1,0,6,0,0,0,4,0,9},
                                            {0,0,0,0,8,6,1,5,0},

                                            {0,3,5,0,9,0,7,6,0},
                                            {0,0,0,7,0,0,0,0,0},
                                            {0,0,9,0,0,5,0,0,0}
                                         };

            Stopwatch sure = new Stopwatch();
            Class1 m = new Class1();
            sure.Start();
            Boolean k = m.fillsudoku(grid_to_solve,0,0);
            if (k)
            {
                sure.Stop();
                Console.WriteLine("Answer found");
                Console.WriteLine("time elapsed = " + sure.ElapsedMilliseconds + " ms \n");
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(grid_to_solve[i, j]);
                    }
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
    }
}
