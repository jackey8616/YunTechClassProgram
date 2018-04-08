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
using System.Collections;

namespace HW02_MST
{
    public partial class Form1 : Form
    {
        Random R = new Random();
        private Graph g;
        private Graph mstG;

        Dictionary<String, Point> pos = new Dictionary<string, Point>();
        int nodeCount, gridSquare, gridWidth, gridHeight;

        public Form1()
        {
            InitializeComponent();
        }
 
        private void readFileBtn_Click(object sender, EventArgs e)
        {
            g = new Graph();
            if (drawZone.Image != null) {
                drawZone.Image = null;
                drawZone.Refresh();
            }

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                g.insertStrEdge(sr.ReadToEnd());
                g.scanNodes();
                sr.Close();
            }

            drawBtn.Enabled = true;
            primBtn.Enabled = true;
            kruskalBtn.Enabled = true;

            initPosition();
        }

        private void initPosition() {
            pos.Clear();
            nodeCount = g.getNodes().Count();
            gridSquare = (int)Math.Sqrt(nodeCount) + 1;
            gridWidth = (drawZone.Width - 20) / gridSquare;
            gridHeight = (drawZone.Height - 20) / gridSquare;
            randomPosition();
        }

        private bool randomPosition() {
            for (int i = 0; i < nodeCount; ++i) {
                Point p = new Point((i % gridSquare) * gridWidth + R.Next(0, gridWidth), (i / gridSquare) * gridHeight + R.Next(0, gridHeight));
                pos.Add(g.getNodes()[i].getName(), p);
            }

            for (int i = 0; i < nodeCount - 1; ++i) {
                for (int j = i + 1; j < nodeCount; ++j) {
                    int x1 = pos.Values.ToArray()[i].X;
                    int y1 = pos.Values.ToArray()[i].Y;
                    int x2 = pos.Values.ToArray()[j].X;
                    int y2 = pos.Values.ToArray()[j].Y;
                    int distance = (int)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                    int gridHalf = (int) (Math.Sqrt(gridWidth * gridWidth + gridHeight * gridHeight) * 0.5);
                    if (distance < gridHalf) {
                        pos.Clear();
                        return randomPosition();
                    }
                }
            }
            return true;
        }

        private void primBtn_Click(object sender, EventArgs e)
        {
            outputTxt.Text = ("Prim: \r\n------------------------------------\r\n");
            mstG = g.primMST();
            outputTxt.AppendText(mstG.ToString() + "==========================");
        }

        private void kruskalBtn_Click(object sender, EventArgs e)
        {
            outputTxt.Text = ("Kruskal: \r\n------------------------------------\r\n");
            mstG = g.kruskalMST();
            outputTxt.AppendText(mstG.ToString() + "==========================");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void drawBtn_Click(object sender, EventArgs e)
        {
            initPosition();
            Bitmap bm = new Bitmap(drawZone.Width, drawZone.Height);
            Graphics G = Graphics.FromImage(bm);
            // Drawing Edges.
            foreach (Edge edge in g.getEdges()) {
                Point src = pos[edge.getSrc().getName()];
                Point dst = pos[edge.getDst().getName()];
                src.Offset(10, 10);
                dst.Offset(10, 10);
                G.DrawLine(new Pen(Color.Black), src, dst);

                Point lineCenter = new Point((src.X + dst.X) / 2, (src.Y + dst.Y) /2);
                G.DrawString(edge.getWeight().ToString(), new Font(new FontFamily("新細明體"), 8.0F), new SolidBrush(Color.Black), lineCenter);
            }
            // Drawing Vertex rectangle.
            foreach (Point p in pos.Values)
                G.FillRectangle(new SolidBrush(Color.Green), new Rectangle(p, new Size(20, 20)));
            // Drawing Vertex name.
            foreach (String name in pos.Keys) {
                Point p = pos[name];
                p.Offset(5, 5);
                G.DrawString(name, new Font(new FontFamily("新細明體"), 8.0F), new SolidBrush(Color.White), p);
            }
            drawZone.Image = bm;
            drawZone.Refresh();
            drawMstBtn.Enabled = true;
        }

        private void drawMstBtn_Click(object sender, EventArgs e)
        {
            Graphics G = Graphics.FromImage(drawZone.Image);
            foreach (Edge edge in mstG.getEdges()) {
                Point src = pos[edge.getSrc().getName()];
                Point dst = pos[edge.getDst().getName()];
                src.Offset(10, 10);
                dst.Offset(10, 10);
                G.DrawLine(new Pen(new SolidBrush(Color.Blue), 5), src, dst);

                Point lineCenter = new Point((src.X + dst.X) / 2, (src.Y + dst.Y) / 2);
                G.DrawString(edge.getWeight().ToString(), new Font(new FontFamily("新細明體"), 8.0F), new SolidBrush(Color.Red), lineCenter);
            }
            // Drawing Vertex rectangle.
            foreach (Point p in pos.Values)
                G.FillRectangle(new SolidBrush(Color.Green), new Rectangle(p, new Size(20, 20)));
            // Drawing Vertex name.
            foreach (String name in pos.Keys)
            {
                Point p = pos[name];
                p.Offset(5, 5);
                G.DrawString(name, new Font(new FontFamily("新細明體"), 8.0F), new SolidBrush(Color.White), p);
            }
            drawZone.Refresh();
        }
    }
}
