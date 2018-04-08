using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02_MST
{
    class Edge
    {

        private Vertex src, dst;
        private int weight;

        public Edge(String src, String dst, int weight) {
            this.src = new Vertex(src);
            this.dst = new Vertex(dst);
            this.weight = weight;
        }

        public Edge(String[] str) {
            this.src = new Vertex(str[0]);
            this.dst = new Vertex(str[1]);
            this.weight = int.Parse(str[2]);
        }

        public Vertex getSrc() {
            return this.src;
        }

        public Vertex getDst() {
            return this.dst;
        }

        public int getWeight() {
            return this.weight;
        }

        override
        public bool Equals(object obj) {
            Edge e = (Edge)obj;
            return (e.getSrc().Equals(this.src) && e.getDst().Equals(this.dst) && e.getWeight() == this.weight) ? true : false;
        }

        override
        public String ToString() {
            return String.Format("SRC: {0:D}, DST: {1:D}, WEIGHT: {2:D}", this.src.ToString(), this.dst.ToString(), this.weight);
        }
    }
}
