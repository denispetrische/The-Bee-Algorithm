using System.Numerics;
using System.Collections.Generic;

namespace Bee
{
    class Vertex
    {
        public List<Vertex> ConnectedVertexes { get; set; }
        public Complex Coordinates { get; set; }
        public BigInteger PathsCounted { get; set; }

        public Vertex()
        {
            ConnectedVertexes = new List<Vertex>();
            PathsCounted = 0;
        }
    }
}
