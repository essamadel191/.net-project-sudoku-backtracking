using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Sudoku
    { 
        public int[,]board;
        public static readonly int empty=0;
        public static readonly int size=9;

        public Sudoku()
        {
            Console.WriteLine("solution start");
        }
        public Sudoku(int[,]board){
            this.board=new int [size,size];
            for (int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++){
                    this.board[i,j]=board[i,j];
                }
            }
        }
            
        // check possibilities
 
        //check row
        private bool isInrow(int row,int x){
            for (int i=0;i<size;i++)
                if(board[row,i]==x)
                    return true;
            
            return false;
        }
        
        //check col
        private bool isInCol(int col , int x){
            for (int i=0;i<size;i++)
                if(board[i,col]==x)
                    return true;
            
            return false;
        }
        
        //check square
        private bool isInSquare(int row, int col, int x)
        {
            int r = row - row % 3;
            int c = col - col % 3;
            for (int i = r; i < r + 3; i++)
                for (int j = c; j < c + 3; j++)
                    if (board[i, j] == x)
                        return true;
                
            
            return false;
        }

        //combine all methods 
        public bool validate(int row, int col, int x)
        {
            return !isInrow(row, x) && !isInCol(col, x) && isInSquare(row, col, x);
        }

        //display 
        public void display()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write( board[i,j]);
                }
                
                Console.WriteLine("\n");
            }
            //Console.WriteLine("\n");

        }

        public bool solve()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == 0)
                    {
                        for (int x = 1; x <= size; x++)
                        {
                            if (validate(row, col, x))
                            {
                                board[row, col] = x;
                                if (solve())
                                {
                                    return true;
                                }
                                else
                                {
                                    board[row, col] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true; // sudoku solved
        }
        // end solve


    }
}
