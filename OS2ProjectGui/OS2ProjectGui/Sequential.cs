using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2ProjectGui
{
    class Sequential
    {

        public static readonly int empty = 0;
        public static readonly int size = 9;


        public int[] find_empty(int[,] bo)
        {
            int[] a = new int[2];
            a[0] = 5555;
            a[1] = 4444;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (bo[i, j] == 0)
                    {
                        a[0] = i;
                        a[1] = j;
                        return a;
                    }
                }
            }
            return a;
        }

        public bool valid(int[,] bo, int x, int[] pos)
        {
            //check row
            for (int i = 0; i < 9; i++)
            {
                if (bo[pos[0], i] == x && pos[1] != i)
                    return false;
            }
            //check col
            for (int i = 0; i < 9; i++)
            {
                if (bo[i, pos[1]] == x && pos[0] != i)
                    return false;
            }
            //check box
            int box_x = pos[1] / 3;
            int box_y = pos[0] / 3;
            for (int i = box_y * 3; i < (box_y * 3 + 3); i++)
            {
                for (int j = box_x * 3; j < (box_x * 3 + 3); j++)
                {
                    if (bo[i, j] == x && i != pos[0] && j != pos[1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool solve(int[,] bo)
        {
            int[] find = find_empty(bo);
            if (find[0] == 5555 && find[1] == 4444)
            {
                return true;
            }
            else
            {
                int row = find[0];
                int col = find[1];

                for (int i = 1; i <= 9; i++)
                {
                    if (valid(bo, i, find))
                    {
                        bo[row, col] = i;
                        if (solve(bo))
                            return true;

                        bo[row, col] = 0;
                    }

                }

            }
            return false;
        }

    }
}
