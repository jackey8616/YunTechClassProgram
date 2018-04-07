using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HW02_MST
{
    public partial class Form1 : Form
    {

        private List<Edge> edges = new List<Edge>();

        public Form1()
        {
            InitializeComponent();
        }

        private void initEdge(String input) {
            MatchCollection matches = Regex.Matches(input, "([0-9]+,[0-9]+,[0-9]+)");
            foreach (Match s in matches)
                edges.Add(new Edge(s.ToString().Split(',')));
            foreach (Edge e in edges)
                Console.WriteLine(e.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                initEdge( sr.ReadToEnd());
                sr.Close();
            }
        }
    }
}
