using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Class1
    {
        Thread t1;
        Thread t2;
        Thread t3;

        public Boolean fillsudoku(int[,] sudoku, int row, int col)
        {
            if (row < 9)
            {
                if (sudoku[row, col] != 0)
                {
                    if (col < 8)
                    {
                        return fillsudoku(sudoku, row, col + 1);
                    }
                    else if (row < 8)
                    {
                        return fillsudoku(sudoku, row + 1, 0);
                    }
                    return true;
                }
                else
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (checking(sudoku, row, col, i))
                        {        // <- checking function
                            t1.Abort();
                            t2.Abort();
                            t3.Abort();
                            sudoku[row, col] = i;
                            if (col == 8)
                            {
                                if (fillsudoku(sudoku, row + 1, 0))
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (fillsudoku(sudoku, row, col + 1))
                                {
                                    return true;
                                }
                            }
                            sudoku[row, col] = 0;
                        }

                    }
                    return false;
                }
            }
            return true;
        }


        protected Boolean s1 = true, s2 = true, s3 = true;

        public Boolean checking(int[,] sudoku, int row, int col, int num)
        {
            

            t1 = new Thread(() => { s1 = check_row(sudoku, row, num); });
            t2 = new Thread(() => { s2 = check_col(sudoku, col, num); });
            t3 = new Thread(() => { s3 = check_box(sudoku, row, col, num); });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            
            /*
            s1 = check_row(sudoku, row, num);
            s2 = check_col(sudoku, col, num);
            s3 = check_box(sudoku, row, col, num);
            */
            return s1 && s2 && s3;
        }

        public Boolean check_row(int[,] sudoku, int row, int num)
        {
            Boolean flag = true;
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[row, i] == num)
                {
                    flag = false;
                    break;
                }
            }
            return flag;

        }
        public Boolean check_col(int[,] sudoku, int col, int num)
        {
            Boolean flag = true;
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, col] == num)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public Boolean check_box(int[,] sudoku, int row, int col, int num)
        {
            Boolean flag = true;
            int rowS = (row / 3) * 3;
            int colS = (col / 3) * 3;
            for (int i = rowS; i < (rowS + 3); i++)
            {
                for (int j = colS; j < (colS + 3); j++)
                {
                    if (sudoku[i, j] == num)
                    {
                        flag = false;
                        break;
                    }
                }
            }

            return flag;
        }

    }

    
}
