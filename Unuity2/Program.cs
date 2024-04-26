using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Unuity2
{
    class Edge
    {
        public int Vertex1;
        public int Vertex2;
        public double Length;

        public Edge(int v1, int v2, double length)
        {
            Vertex1 = v1;
            Vertex2 = v2;
            Length = length;
        }
    }

    class Program
    {
        static void Main()
        {
            int n = 5; // Количество точек
            List<Tuple<double, double>> points = new List<Tuple<double, double>>
        {
            new Tuple<double, double>(0, 0),
            new Tuple<double, double>(1, 1),
            new Tuple<double, double>(2, 2),
            new Tuple<double, double>(3, 3),
            new Tuple<double, double>(4, 4)
        };

            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double length = Math.Sqrt(Math.Pow(points[i].Item1 - points[j].Item1, 2) + Math.Pow(points[i].Item2 - points[j].Item2, 2));
                    edges.Add(new Edge(i, j, length));
                }
            }

            edges.Sort((a, b) => a.Length.CompareTo(b.Length));

            int[] parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                int root1 = Find(parent, edge.Vertex1);
                int root2 = Find(parent, edge.Vertex2);

                if (root1 != root2)
                {
                    Console.WriteLine("Добавление ребра между вершинами {0} и {1} с длиной {2}", edge.Vertex1, edge.Vertex2, edge.Length);
                    parent[root1] = root2;
                }
            }
        }

        static int Find(int[] parent, int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent, parent[i]);
            return parent[i];
        }
    }
}

