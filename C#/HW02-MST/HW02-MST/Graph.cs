using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW02_MST
{
    class Graph
    {
        private List<Vertex> nodes = new List<Vertex>();
        private List<Edge> edges = new List<Edge>();

        public Graph() { }

        public Graph(List<Vertex> nodes, List<Edge> edges) {
            this.nodes = nodes;
            this.edges = edges;
        }

        public void scanNodes() {
            foreach (Edge e in edges) {
                if (!nodes.Contains(e.getSrc()))
                    nodes.Add(e.getSrc());
                if (!nodes.Contains(e.getDst())) 
                    nodes.Add(e.getDst());
            }
        }

        public void insertStrEdge(String input) {
            MatchCollection matches = Regex.Matches(input, "([0-9]+,[0-9]+,[0-9]+)");
            foreach (Match s in matches)
                this.edges.Add(new Edge(s.ToString().Split(',')));
        }

        public Graph primMST() {
            if (nodes.Count == 0)
                scanNodes();
            List<Edge> E = edges.ToList();
            E.Sort((x, y) => { return x.getWeight().CompareTo(y.getWeight()); });

            List<Vertex> Vn = new List<Vertex>() { nodes[0]};
            List<Edge> En = new List<Edge>();
            
            while(!nodes.All(Vn.Contains)) {
                foreach(Edge e in E) {
                    Console.WriteLine(e.ToString());
                    if (Vn.Contains(e.getSrc()) && !Vn.Contains(e.getDst()) && nodes.Contains(e.getDst())) {
                        Vn.Add(e.getDst());
                        En.Add(e);
                        E.Remove(e);
                        break;
                    } else if (Vn.Contains(e.getDst()) && !Vn.Contains(e.getSrc()) && nodes.Contains(e.getSrc())) {
                        Vn.Add(e.getSrc());
                        En.Add(e);
                        E.Remove(e);
                        break;
                    }
                }
                Console.WriteLine("-----");
            }

            return new Graph(Vn, En);
        }

        public Graph kruskalMST() {
            if (nodes.Count == 0)
                scanNodes();

            List<Edge> E = edges.ToList();
            E.Sort((x, y) => { return x.getWeight().CompareTo(y.getWeight()); });
            Dictionary<String, String> parent = new Dictionary<String, String>();
            foreach (Vertex v in nodes)
                parent.Add(v.getName(), null);

            List<Vertex> Vn = new List<Vertex>();
            List<Edge> En = new List<Edge>();

            String find(String vName) {
                while (parent[vName] != null)
                    vName = parent[vName];
                return vName;
            };

            while (En.Count != nodes.Count() - 1) {
                foreach(Edge e in E) {
                    Console.WriteLine(e.ToString());
                    String m = find(e.getSrc().getName());
                    String n = find(e.getDst().getName());
                    if (!m.Equals(n)) {
                        parent[n] = m;
                        if (!Vn.Contains(e.getSrc()))
                            Vn.Add(e.getSrc());
                        if (!Vn.Contains(e.getDst()))
                            Vn.Add(e.getDst());
                        En.Add(e);
                    }
                }
            }

            return new Graph(Vn, En);
        }

        public List<Vertex> getNodes() {
            return this.nodes;
        }

        public List<Edge> getEdges() {
            return this.edges;
        }

        public void addEdge(Edge e) {
            this.edges.Add(e);
        }

        override
        public String ToString() {
            String output = "Nodes:\r\n{ ";
            foreach (Vertex v in nodes)
                output += v.ToString() + " ";
            output += "}\r\nEdges:\r\n";
            foreach (Edge e in edges)
                output += e.ToString() + "\r\n";
            return output;
        }
    }
}
