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

namespace OS2ProjectGui
{
    public partial class Form1 : Form
    {
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
        Stopwatch sure = new Stopwatch();
        const int cColWidth = 45;
        const int cRowHeigth = 45;
        const int cMaxCell = 9;
        const int cSidelength = cColWidth * cMaxCell + 3;
        DataGridView DGV;
        public List<int> gridd = new List<int>();

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
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                DGV.Columns.Add(TxCol);
                DGV.Columns[i].Name = "Col " + (i + 1).ToString();
                DGV.Columns[i].Width = cColWidth;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeigth;
                DGV.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            DGV.Columns[2].DividerWidth = 2;
            DGV.Columns[5].DividerWidth = 2;
            DGV.Rows[2].DividerHeight = 2;
            DGV.Rows[5].DividerHeight = 2;

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

                if (ass)
                    MessageBox.Show("Solved");
                else
                {
                    MessageBox.Show("Unable to solve");
                }
            }



            if(comboBox1.SelectedIndex==1){

            Class1 m = new Class1();
            sure.Start();
            Boolean k = m.fillsudoku(m.sudoku,0,0);
            sure.Stop();
            TimeSpan ts = sure.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            textBox1.Text=elapsedTime;

            if (k)
            {
                MessageBox.Show("Solved");
            }
            else
            {
                MessageBox.Show("Unable to solve");
            }
        }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text((String)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to close this form?", "Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        
        }

        private void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid_to_solve[i, j] = 0;
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
            //and reset the grid in gui
        }


    }
}


