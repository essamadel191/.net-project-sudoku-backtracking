using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] grid_to_solve={
                                             {0,0,0,3,0,0,2,0,0},
                                             {0,0,0,0,0,8,0,0,0},
                                             {0,7,8,0,6,0,3,4,0},

                                             {0,4,2,5,1,0,0,0,0},
                                             {1,0,6,0,0,0,4,0,9},
                                             {0,0,0,0,8,6,1,5,0},

                                             {0,3,5,0,9,0,7,6,0},
                                             {0,0,0,7,0,0,0,0,0},
                                             {0,0,9,0,0,5,0,0,0}
                                         };
            var s = new sudokuSolver();
            if (s.solve(grid_to_solve))
                s.display(grid_to_solve);
            else
            {
                Console.WriteLine("unable");
            }
            

            
        }
    }
}
