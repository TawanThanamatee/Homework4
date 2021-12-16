using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HW4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] Graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            Dijkstra dijk = new Dijkstra();
            dijk.DijkstraAlgo(Graph, 0);
        }
    }

    public class Dijkstra
    {
        static int NumberOfVertices = 9;

        int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < NumberOfVertices; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }

        void PrintPaths(int[] dist, int n, int srcVert)
        {
            Console.Write("Vertex Distance from Source {0}\n", srcVert);
            for (int i = 0; i < NumberOfVertices; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
            }
        }
        public void DijkstraAlgo(int[,] graph, int srcVert)
        {
            int[] dist = new int[NumberOfVertices];
            bool[] sptSet = new bool[NumberOfVertices];

            for (int i = 0; i < NumberOfVertices; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[srcVert] = 0;

            for (int count = 0; count < NumberOfVertices - 1; count++)
            {
                int minDistIndx = minDistance(dist, sptSet);

                sptSet[minDistIndx] = true;

                for (int indx = 0; indx < NumberOfVertices; indx++)
                {
                    if (!sptSet[indx] && graph[minDistIndx, indx] != 0 && dist[minDistIndx] != int.MaxValue && dist[minDistIndx] + graph[minDistIndx, indx] < dist[indx])
                    {
                        dist[indx] = dist[minDistIndx] + graph[minDistIndx, indx];
                    }
                }
            }
            PrintPaths(dist, NumberOfVertices, srcVert);
        }
    }
}