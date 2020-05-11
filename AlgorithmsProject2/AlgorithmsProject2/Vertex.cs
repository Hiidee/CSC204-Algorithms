using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProject2
{
    class Vertex
    {
        public List<Vertex> ConnectedVertices = new List<Vertex>();
        public int Key { get; set; } = int.MaxValue;
        public int Parent { get; set; } = -1;
        public int Data { get; set; }
        public bool IsProcessed { get; set; }
        public int Weight { get; set; }
    }
}
