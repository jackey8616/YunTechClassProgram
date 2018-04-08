using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW02_MST
{
    class Vertex
    {

        private String name;

        public Vertex(String name)
        {
            this.name = name;
        }

        public String getName() {
            return this.name;
        }

        override
        public bool Equals(Object v) {
            return ((Vertex) v).getName().Equals(this.name) ? true : false;
        }

        override
        public String ToString() {
            return this.name;
        }
    }
}
