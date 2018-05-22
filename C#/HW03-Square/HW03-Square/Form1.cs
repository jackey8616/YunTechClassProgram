using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW03_Square
{
    public partial class Form1 : Form
    {
        int N;
        int xSize, ySize, puzzleCount;
        char[,] square;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                N = int.Parse(sr.ReadLine());
                for (int i = 0; i < N; ++i) {
                    string[] s = sr.ReadLine().Split(' ');
                    xSize = int.Parse(s[0]);
                    ySize = int.Parse(s[1]);
                    puzzleCount = int.Parse(s[2]);
                    square = new char[xSize, ySize];
                    for (int j = 0; j < xSize; ++j) {
                        String row = sr.ReadLine();
                        int count = 0;
                        foreach(char c in row) {
                            square[j, count] = c;
                            count++;
                        }
                        textBox1.Text += row + "\r\n";
                    }

                    for (int j = 0; j < puzzleCount; ++j) {
                        String a = sr.ReadLine();
                        int x = int.Parse(a.Split(' ')[0]), y = int.Parse(a.Split(' ')[1]);
                        textBox1.Text += a + " : " + getSize(x, y) + "\r\n";
                        
                    }
                    textBox1.Text += "\r\n================================================\r\n";
                }
                sr.Close();
            }
        }

        private int getSize(int x, int y) {
            int size = 1;
            char start = square[x, y];
            Point rightLoc = new Point(x + 1, y - 1), leftLoc = new Point(x - 1, y + 1);
            while(true) {
                for (int i = rightLoc.Y; i < leftLoc.Y; ++i)
                    for (int j = leftLoc.X; j < rightLoc.X; ++j)
                        if (i < 0 || j < 0 || i >= xSize || j >= ySize || square[i, j] != start)
                            return size;
                rightLoc.Offset(1, -1);
                leftLoc.Offset(-1, 1);
                size += 2;
            }
        }

    }
}
