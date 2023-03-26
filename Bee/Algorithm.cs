using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace Bee
{
    public class Algorithm
    {
        public static void Main(string[] args)
        {
            FindPaths(2);
        }

        private static void FindPaths(int n)
        {
            if (n >= 2 && n <= 200)
            {
                var array = CreateVertexDictionary(n);
                CreateBoundaries(array);

                BigInteger result = CountPaths(array[0]);

                Console.WriteLine(result.ToString());
                Console.ReadLine();
            }
        }

        private static Dictionary<Complex,Vertex> CreateVertexDictionary(int radius)
        {
            var outputDictionary = new Dictionary<Complex, Vertex>();

            int length = 2 * radius - 1;
            int marginEnd = radius;
            int marginStart = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = marginStart; j < length; j++)
                {
                    if (j >= marginEnd)
                    {
                        continue;
                    }
                    else
                    {
                        Vertex temp = new Vertex() {Coordinates = new Complex(i,j)};
                        outputDictionary.Add(temp.Coordinates, temp);
                    }
                }

                if (marginEnd < length)
                {
                    marginEnd++;
                }
                else
                {
                    marginStart++;
                }
            }

            return outputDictionary;
        }

        private static void CreateBoundaries(Dictionary<Complex,Vertex> inputDictionary)
        {
            Complex oneZero = new Complex(1, 0);
            Complex zeroOne = new Complex(0, 1);
            Complex oneOne = new Complex(1, 1);

            foreach (Vertex item in inputDictionary.Values)
            {
                Vertex tempOneZero;
                Vertex tempZeroOne;
                Vertex tempOneOne;

                inputDictionary.TryGetValue(item.Coordinates + oneZero, out tempOneZero);
                inputDictionary.TryGetValue(item.Coordinates + zeroOne, out tempZeroOne);
                inputDictionary.TryGetValue(item.Coordinates + oneOne, out tempOneOne);

                if (tempOneZero != null)
                {
                    item.ConnectedVertexes.Add(tempOneZero);
                }

                if (tempZeroOne != null)
                {
                    item.ConnectedVertexes.Add(tempZeroOne);
                }

                if (tempOneOne != null)
                {
                    item.ConnectedVertexes.Add(tempOneOne);
                }
            }
        }

        private static BigInteger CountPaths(Vertex inputVertex)
        {
            if (inputVertex.PathsCounted != 0)
            {
                return inputVertex.PathsCounted;
            }

            if (inputVertex.ConnectedVertexes.Count == 0)
            {
                return 1;
            }

            BigInteger sum = 0;

            foreach (Vertex item in inputVertex.ConnectedVertexes)
            {
                sum += CountPaths(item);
            }

            inputVertex.PathsCounted = sum;
            return sum;
        }
    }
}
