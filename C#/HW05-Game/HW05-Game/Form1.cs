using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_Game
{
    public partial class Form1 : Form
    {
        public Random random = new Random();
        public GroupBox[,] groups = new GroupBox[3, 3];
        public TextBox[,] txts = new TextBox[9, 9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateGroupBox();
            generateSodoku();
            randomSodoku();
        }

        private void generateGroupBox() {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    GroupBox gb = new GroupBox();
                    gb.Name = j + "," + i;
                    gb.Text = "";
                    gb.Size = new Size(85, 100);
                    gb.Location = new Point(12 + j * (85 + 6), 12 + i * (94 + 6));
                    this.generateTxtBox(gb);
                    this.Controls.Add(gb);
                    groups[j, i] = gb;
                }
            }
        }

        private void generateTxtBox(GroupBox gb)
        {
            int gbI, gbJ;
            gbI = int.Parse(gb.Name.Split(',')[0]);
            gbJ = int.Parse(gb.Name.Split(',')[1]);
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    TextBox tb = new TextBox();
                    tb.Name = (gbI * 3 + j) + "," + (gbJ * 3 + i);
                    //tb.Text = (gbI * 3 + j) + "," + (gbJ * 3 + i); Debug for check index.
                    tb.Size = new Size(20, 22);
                    tb.Location = new Point(6 + j * (20 + 6), 12 + i * (22 + 6));
                    tb.KeyPress += fillCheck;
                    tb.MaxLength = 1;
                    gb.Controls.Add(tb);
                    txts[gbI * 3 + j, gbJ * 3 + i] = tb;
                }
            }
        }

        private void generateSodoku() {
            int[,] num = {
                { 1, 4, 7, 8, 2, 5, 6, 9, 3 },
                { 2, 5, 8, 9, 3, 6, 7, 1, 4 },
                { 3, 6, 9, 1, 4, 7, 8, 2, 5 },
                { 4, 7, 1, 2, 5, 8, 9, 3, 6 },
                { 5, 8, 2, 3, 6, 9, 1, 4, 7 },
                { 6, 9, 3, 4, 7, 1, 2, 5, 8 },
                { 7, 1, 4, 5, 8, 2, 3, 6, 9 },
                { 8, 2, 5, 6, 9, 3, 4, 7, 1 },
                { 9, 3, 6, 7, 1, 4, 5, 8, 2 }
            };
            for (int i = 0; i < 9; ++i) {
                for (int j = 0; j < 9; ++j) {
                    txts[j, i].Text = num[j, i].ToString();
                    txts[j, i].Enabled = false;
                }
            }
        }

        private void randomSodoku() {
            //int N = random.Next(30, 40);
            int N = random.Next(75, 80);
            for (int n = 0; n < N; ++n)
            {
                int x = random.Next(0, 9);
                int y = random.Next(0, 9);
                txts[x, y].Text = "";
                txts[x, y].Enabled = true;
            }
        }


        private bool checkDuplicate(int x, int y) {
            bool flag = false;
            String c = txts[x, y].Text;
            for (int k = 0; k < 9; ++k)
            {
                if (txts[x, k].Text == c && k != y)
                {
                    txts[x, k].BackColor = Color.Red;
                    flag = true;
                }
                else if (txts[k, y].Text == c && k != x)
                {
                    txts[k, y].BackColor = Color.Red;
                    flag = true;
                }
            }
            int gridX = x / 3;
            int gridY = y / 3;
            for (int k = gridY * 3; k < gridY + 3; ++k) {
                for (int l = gridX * 3; l < gridX + 3; ++l)
                {
                    if (txts[l, k].Text == c && x != l && y != k)
                    {
                        txts[l, k].BackColor = Color.Red;
                        flag = true;
                    }
                }
            }
            return flag;
        }

        private bool checkWin() {
            for (int i = 0; i < 9; ++i) {
                for (int j = 0; j < 9; ++j) {
                    if (txts[j, i].Text == "")
                        return false;
                }
            }
            return true;
        }

        public void fillCheck(object sender, EventArgs e) {
            TextBox tb = (TextBox)sender;
            KeyPressEventArgs eve = (KeyPressEventArgs) e;
            try
            {
                int num = int.Parse(eve.KeyChar.ToString());
                if (num != 0)
                {
                    for (int i = 0; i < 9; ++i)
                        for (int j = 0; j < 9; ++j)
                            txts[i, j].BackColor = Color.White;
                    tb.Text = num.ToString();
                    int x, y;
                    x = int.Parse(tb.Name.Split(',')[0]);
                    y = int.Parse(tb.Name.Split(',')[1]);
                    if (checkDuplicate(x, y) && checkWin()) {
                        MessageBox.Show("You Win, Next Match!");
                        generateSodoku();
                        randomSodoku();
                    }
                }
            }
            catch (Exception)
            {
                
            }
            eve.Handled = true;
        }
    }
}
