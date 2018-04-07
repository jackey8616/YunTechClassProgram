using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02_MST
{
    class Edge
    {

        private int src, dst, weight;

        public Edge(int src, int dst, int weight) {
            this.src = src;
            this.dst = dst;
            this.weight = weight;
        }

        public Edge(String[] str) {
            this.src = int.Parse(str[0]);
            this.dst = int.Parse(str[1]);
            this.weight = int.Parse(str[2]);
        }

        override
        public String ToString() {
            return String.Format("SRC: {0:D}, DST: {1:D}, WEIGHT: {2:D}", this.src, this.dst, this.weight);
        }
    }
}
