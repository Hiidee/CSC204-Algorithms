using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace AlgorithmsProject2
{
    class MST
    {
        List<Vertex> vertices = new List<Vertex>();
        int[][] AdjMatrix;
        public MST(int[][] AdjMatrix)
        {
            this.AdjMatrix = AdjMatrix;
            int vertexCount = AdjMatrix.GetLength(0);

            // convert adjacency matrix into a list of Vertices.            
            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex
                {
                    // Set default values on each vertex.
                    Key = int.MaxValue, //infinity,
                    Parent = -1, // "nil"
                    Data = i
                };
                this.vertices.Add(vertex);
            }
            for (int i = 0; i < vertexCount; i++)
            {
                // i is 0
                for (int n = 0; n < vertexCount; n++)
                {
                    // n is 0
                    var currentWeight = AdjMatrix[i][n];
                    if (currentWeight > 0)
                    {
                        var connection = this.vertices.ElementAtOrDefault(n);
                        var NewVertex = new Vertex() { Key = n, Weight = currentWeight };
                        this.vertices[i].ConnectedVertices.Add(NewVertex);
                    }
                }
            }
        }
        public void Traverse(int pointer)
        {
            var vertex = this.vertices[pointer];

            // r.key = 0
            this.vertices[pointer].Key = 0;

            var queue = new PriorityQueue(this.vertices);

            while (queue.Count > 0)
            {
                Vertex minVertex = queue.ExtractMin();
                int u = minVertex.Data;
                this.vertices[u].IsProcessed = true;
                int[] edges = this.AdjMatrix[minVertex.Data];

                // for each edge in vertex                
                for (int v = 0; v < edges.Length; v++)
                {
                    // if v has not been processed, 
                    if (this.AdjMatrix[u][v] > 0 && !vertices[v].IsProcessed && this.AdjMatrix[u][v] < vertices[v].Key)
                    {
                        vertices[v].Parent = u;
                        vertices[v].Key = this.AdjMatrix[u][v];
                        //updating priority in queue with key as priority
                        queue.UpdatePriority(vertices[v], vertices[v].Key);
                    }
                }
            }
            //printing results
            int totalWeight = 0;
            foreach (Vertex v in vertices)
            {
                if (v.Parent >= 0)
                {
                    Console.WriteLine("Vertex {0} to Vertex {1}", v.Parent, v.Data, v.Key);
                    totalWeight += v.Key;
                }
            }
            //Console.WriteLine("Total Weight: {0}", totalWeight);
        }
        public void GetTotalCost(int pointer)
        {
            var vertex = this.vertices[pointer];

            // r.key = 0
            this.vertices[pointer].Key = 0;

            var queue = new PriorityQueue(this.vertices);

            while (queue.Count > 0)
            {
                Vertex minVertex = queue.ExtractMin();
                int u = minVertex.Data;
                this.vertices[u].IsProcessed = true;
                int[] edges = this.AdjMatrix[minVertex.Data];

                // for each edge in vertex                
                for (int v = 0; v < edges.Length; v++)
                {
                    // if v has not been processed, 
                    if (this.AdjMatrix[u][v] > 0 && !vertices[v].IsProcessed && this.AdjMatrix[u][v] < vertices[v].Key)
                    {
                        vertices[v].Parent = u;
                        vertices[v].Key = this.AdjMatrix[u][v];
                        //updating priority in queue with key as priority
                        queue.UpdatePriority(vertices[v], vertices[v].Key);
                    }
                }
            }
            //printing results
            int totalWeight = 0;
            foreach (Vertex v in vertices)
            {
                if (v.Parent >= 0)
                {
                    totalWeight += v.Key;
                }
            }
            Console.WriteLine("Total Cost: {0}", totalWeight);
        }
        public void GetNeighborsAndWeights(int pointer)
        {
            var vertex = this.vertices[pointer];

            var ordered = vertex.ConnectedVertices.OrderByDescending(x => x.Weight);

            foreach (var v in ordered)
            {
                Console.WriteLine("node " + v.Key + " - " + v.Weight);
            }
        }
    }
}
