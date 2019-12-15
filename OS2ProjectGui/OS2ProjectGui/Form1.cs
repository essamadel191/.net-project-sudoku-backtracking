using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OS2ProjectGui
{
    public partial class Form1 : Form
    {
        int[,] start ={
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},

                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},

                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0}


                      };
        int[,] grid_to_solve ={
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

        int[,] end ={
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},

                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},

                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0},
                                             {0,0,0,0,0,0,0,0,0}


                      };

        Stopwatch sure = new Stopwatch();
        OpenFileDialog openFile;
        SaveFileDialog saveFile;
        const int cColWidth = 45;
        const int cRowHeigth = 45;
        const int cMaxCell = 9;
        const int cSidelength = cColWidth * cMaxCell + 3;

        DataGridView DGV;
        DataGridViewRow row;
        DataGridViewTextBoxColumn TxCol;

        public List<int> gridd = new List<int>();
        public List<int> startGrid = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DGV = new DataGridView();
            DGV.Name = "DGV";
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToAddRows = false;
            
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = false;
            DGV.GridColor = Color.DarkBlue;
            DGV.DefaultCellStyle.BackColor = Color.AliceBlue;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(cSidelength, cSidelength);
            DGV.Location = new Point(50, 50);
            DGV.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            DGV.ForeColor = Color.DarkBlue;
            DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 81 cells
            for (int i = 0; i < cMaxCell; i++)
            {
                TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                
                DGV.Columns.Add(TxCol);
                DGV.Columns[i].Name = "Col " + (i + 1).ToString();
                DGV.Columns[i].Width = cColWidth;

                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                row = new DataGridViewRow();
                row.Height = cRowHeigth;
                DGV.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            DGV.Columns[2].DividerWidth = 5;
            DGV.Columns[5].DividerWidth = 5;
            DGV.Rows[2].DividerHeight = 5;
            DGV.Rows[5].DividerHeight = 5;
            
            Controls.Add(DGV);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (comboBox1.SelectedIndex == 0)
            {
                var s = new Sequential();
                sure.Start();
                bool ass = s.solve(grid_to_solve);
                sure.Stop();
                TimeSpan ts = sure.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                textBox1.Text = elapsedTime;
                /*for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        gridd.Add(grid_to_solve[x, y]);
                    }
                }
                int[] grid1d = gridd.ToArray();*/
                DGV.ClearSelection();
                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    for (int j = 0; j < DGV.Columns.Count; j++)
                    {
                        DGV.Rows[i].Cells[j].Value= grid_to_solve[i,j];
                    }
                }

                    
               
                if (ass)
                    MessageBox.Show("Solved");
                    
                    
                else
                {
                    MessageBox.Show("Unable to solve");
                }
            }

           

            if (comboBox1.SelectedIndex == 1)
            {

                Class1 m = new Class1();
                sure.Start();
                Boolean k = m.fillsudoku(grid_to_solve, 0, 0);
                sure.Stop();

                TimeSpan ts = sure.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                // Format and display the TimeSpan value.
                textBox1.Text = elapsedTime;
                
                if (k)
                {
                    MessageBox.Show("Solved");
                    
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                           end[i,j] = grid_to_solve[i, j];
                        }
                    }
                    DGV.ClearSelection();
                    for (int i = 0; i < DGV.Rows.Count; i++)
                    {
                        for (int j = 0; j < DGV.Columns.Count; j++)
                        {
                            DGV.Rows[i].Cells[j].Value = grid_to_solve[i, j];
                        }
                    }
                
                }
                else
                {
                    MessageBox.Show("Unable to solve");
                }
            }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //text((String)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to close this form?", "Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        
        }

        private void reset()
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    DGV.Rows[i].Cells[j].Value = " ";
                    grid_to_solve[i, j] = 0;
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
            //and reset the grid in gui
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFile=new OpenFileDialog();
            openFile.Title = "Open sudoku file";
            openFile.InitialDirectory = Directory.GetCurrentDirectory() + "\\Tables";
            openFile.Filter = "Txt files (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                loadFrom(openFile.FileName);
            }           
            
        }

        private void loadFrom(String filename)
        {
            char[,] data = new char[9,9];
           
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    List<char> columns = new List<char>();
                    // Read the stream to a string, and write the string to the console.
                    while (!sr.EndOfStream)
                    {
                        columns.Add((char)sr.Read());
                    }
                    char[] data1 = columns.ToArray();
                    int[] data2 = new int[81];
                    for (int i = 0; i < data.Length; i++)
                    {
                        

                        if (data1[i] == '1')
                        {
                            data2[i] = 1;
                        }
                        if (data1[i] == '2')
                            data2[i] = 2;
                        if (data1[i] == '3')
                            data2[i] = 3;
                        if (data1[i] == '4')
                            data2[i] = 4;
                        if (data1[i] == '5')
                            data2[i] = 5;
                        if (data1[i] == '6')
                            data2[i] = 6;
                        if (data1[i] == '7')
                            data2[i] = 7;
                        if (data1[i] == '8')
                            data2[i] = 8;
                        if (data1[i] == '9')
                        {
                            data2[i] = 9;
                        }

                    }

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            grid_to_solve[i, j] = data2[i * 9 + j];
                        }
                    }
                    

                }
                
                

            }
            catch (IOException e)
            {
                MessageBox.Show("The file could not be read: " +e.Message);
                
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}


