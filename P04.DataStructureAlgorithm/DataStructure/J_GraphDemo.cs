﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.DataStructure
{
    public class J_GraphDemo
    {
        public static void Show()
        {

            {
                //Build undirected Graph
                Graph graph = new Graph(4);
                graph.AddVertex("A");
                graph.AddVertex("B");
                graph.AddVertex("C");
                graph.AddVertex("D");

                graph.AddEdge(0, 1);
                graph.AddEdge(1, 0);
                graph.AddEdge(1, 3);
                graph.AddEdge(3, 1);

                graph.Show();
            }
            {
                //directed graph+top sort
                Graph theGraph = new Graph(4);
                theGraph.AddVertex("A");
                theGraph.AddVertex("B");
                theGraph.AddVertex("C");
                theGraph.AddVertex("D");
                theGraph.AddEdge(0, 1);
                theGraph.AddEdge(1, 2);
                theGraph.AddEdge(2, 3);
                theGraph.TopologicalSort();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
            {
                //TopologicalSort
                Graph theGraph = new Graph(6);
                theGraph.AddVertex("CS1");
                theGraph.AddVertex("CS2");
                theGraph.AddVertex("DS");
                theGraph.AddVertex("OS");
                theGraph.AddVertex("ALG");
                theGraph.AddVertex("AL");
                theGraph.AddEdge(0, 1);
                theGraph.AddEdge(1, 2);
                theGraph.AddEdge(1, 5);
                theGraph.AddEdge(2, 3);
                theGraph.AddEdge(2, 4);
                theGraph.TopologicalSort();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
            {
                //depth first and breadth first
                Graph aGraph = new Graph(13);
                aGraph.AddVertex("A");
                aGraph.AddVertex("B");
                aGraph.AddVertex("C");
                aGraph.AddVertex("D");
                aGraph.AddVertex("E");
                aGraph.AddVertex("F");
                aGraph.AddVertex("G");
                aGraph.AddVertex("H");
                aGraph.AddVertex("I");
                aGraph.AddVertex("J");
                aGraph.AddVertex("K");
                aGraph.AddVertex("L");
                aGraph.AddVertex("M");
                aGraph.AddEdge(0, 1);
                aGraph.AddEdge(1, 2);
                aGraph.AddEdge(2, 3);
                aGraph.AddEdge(0, 4);
                aGraph.AddEdge(4, 5);
                aGraph.AddEdge(5, 6);
                aGraph.AddEdge(0, 7);
                aGraph.AddEdge(7, 8);
                aGraph.AddEdge(8, 9);
                aGraph.AddEdge(0, 10);
                aGraph.AddEdge(10, 11);
                aGraph.AddEdge(11, 12);
                aGraph.DepthFirstSearch();
                Console.WriteLine();
                aGraph.BreadthFirstSearch();
                Console.WriteLine();
                Console.WriteLine("Finished.");
            }
            {
                //minimum  search tree
                Graph aGraph = new Graph(7);
                aGraph.AddVertex("A");
                aGraph.AddVertex("B");
                aGraph.AddVertex("C");
                aGraph.AddVertex("D");
                aGraph.AddVertex("E");
                aGraph.AddVertex("F");
                aGraph.AddVertex("G");
                aGraph.AddEdge(0, 1);
                aGraph.AddEdge(0, 2);
                aGraph.AddEdge(0, 3);
                aGraph.AddEdge(1, 2);
                aGraph.AddEdge(1, 3);
                aGraph.AddEdge(1, 4);
                aGraph.AddEdge(2, 3);
                aGraph.AddEdge(2, 5);
                aGraph.AddEdge(3, 5);
                aGraph.AddEdge(3, 4);
                aGraph.AddEdge(3, 6);
                aGraph.AddEdge(4, 5);
                aGraph.AddEdge(4, 6);
                aGraph.AddEdge(5, 6);
                Console.WriteLine();
                aGraph.Mst();
            }
        }


    }



    #region CustomGraph
    /// <summary>
    /// Vertex or points 
    /// </summary>
    public class Vertex
    {
        public bool wasVisited;
        public string label;
        public Vertex(string label)
        {
            this.label = label;
            wasVisited = false;
        }
    }
    /// <summary>
    /// Graph
    /// </summary>
    public class Graph
    {
        #region init
        private int NUM_VERTICES = 6;
        private Vertex[] vertices;
        private int[,] adjMatrix;
        int numVerts;
        public Graph(int numvertices)
        {
            NUM_VERTICES = numvertices;
            vertices = new Vertex[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j <= NUM_VERTICES - 1; j++)
                for (int k = 0; k <= NUM_VERTICES - 1; k++)
                    adjMatrix[j, k] = 0;
        }
        public void AddVertex(string label)
        {
            vertices[numVerts] = new Vertex(label);
            numVerts++;
        }
        public void AddEdge(int start, int end)
        {
            adjMatrix[start, end] = 1;
        }
        #endregion

        #region Show
        public void ShowVertex(int v)
        {
            Console.Write(vertices[v].label + " ");
        }

        public void Show()
        {
            foreach (var item in this.vertices)
            {
                Console.WriteLine(item.label);
            }
            for (int j = 0; j <= NUM_VERTICES - 1; j++)
            {
                for (int k = 0; k <= NUM_VERTICES - 1; k++)
                {
                    Console.Write(adjMatrix[j, k] + " ");
                }
                Console.WriteLine();
            }
        }

        public void TopologicalSort()
        {
            Stack<string> gStack = new Stack<string>();
            while (NUM_VERTICES > 0)
            {
                int currVertex = NoSuccessors();
                if (currVertex == -1)
                {
                    Console.WriteLine("Error: graph has cycles.");
                    return;
                }
                gStack.Push(vertices[currVertex].label);
                DelVertex(currVertex);
            }
            Console.Write("Topological sorting order: ");
            while (gStack.Count > 0)
                Console.Write(gStack.Pop() + " ");
        }
        #endregion

        #region Successor
        public int NoSuccessors()
        {
            bool isEdge;
            for (int row = 0; row <= NUM_VERTICES - 1; row++)
            {
                isEdge = false;
                for (int col = 0; col <= NUM_VERTICES - 1; col++)
                {
                    if (adjMatrix[row, col] > 0)
                    {
                        isEdge = true;
                        break;
                    }
                }
                if (!isEdge)
                    return row;
            }
            return -1;
        }
        public void DelVertex(int vert)
        {
            if (vert != NUM_VERTICES - 1)
            {
                for (int j = vert; j < NUM_VERTICES - 1; j++)
                    vertices[j] = vertices[j + 1];
                for (int row = vert; row < NUM_VERTICES - 1; row++)
                    MoveRow(row, NUM_VERTICES);
                for (int col = vert; col < NUM_VERTICES - 1; col++)
                    MoveCol(col, NUM_VERTICES);
            }
            NUM_VERTICES--;
        }
        private void MoveRow(int row, int length)
        {
            for (int col = 0; col <= length - 1; col++)
                adjMatrix[row, col] = adjMatrix[row + 1, col];
        }
        private void MoveCol(int col, int length)
        {
            for (int row = 0; row <= length - 1; row++)
                adjMatrix[row, col] = adjMatrix[row, col + 1];
        }
        #endregion

        #region depth first and breadth first
        /// <summary>
        /// find the adjacent unVisited point
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j <= NUM_VERTICES - 1; j++)
                if ((adjMatrix[v, j] == 1) && (vertices[j].wasVisited == false))
                    return j;
            return -1;
        }
        public void DepthFirstSearch()
        {
            Stack<int> gStack = new Stack<int>();
            vertices[0].wasVisited = true;
            ShowVertex(0);
            gStack.Push(0);
            int v;
            while (gStack.Count > 0)
            {
                v = GetAdjUnvisitedVertex(gStack.Peek());
                if (v == -1)
                    gStack.Pop();
                else
                {
                    vertices[v].wasVisited = true;
                    ShowVertex(v);
                    gStack.Push(v);
                }
            }
            for (int j = 0; j <= NUM_VERTICES - 1; j++)
                vertices[j].wasVisited = false;
        }
        public void BreadthFirstSearch()
        {
            Queue<int> gQueue = new Queue<int>();
            vertices[0].wasVisited = true;
            ShowVertex(0);
            gQueue.Enqueue(0);
            int vert1, vert2;
            while (gQueue.Count > 0)
            {
                vert1 = gQueue.Dequeue();
                vert2 = GetAdjUnvisitedVertex(vert1);
                while (vert2 != -1)
                {
                    vertices[vert2].wasVisited = true;
                    ShowVertex(vert2);
                    gQueue.Enqueue(vert2);
                    vert2 = GetAdjUnvisitedVertex(vert1);
                }
            }
            for (int i = 0; i <= NUM_VERTICES - 1; i++)
                vertices[i].wasVisited = false;
        }
        #endregion

        #region  Minimum Cost Spanning Tree
        public void Mst()
        {
            Stack<int> gStack = new Stack<int>();
            vertices[0].wasVisited = true;
            gStack.Push(0);
            int currVertex, ver;
            while (gStack.Count > 0)
            {
                currVertex = gStack.Peek();
                ver = GetAdjUnvisitedVertex(currVertex);
                if (ver == -1)
                    gStack.Pop();
                else
                {
                    vertices[ver].wasVisited = true;
                    gStack.Push(ver);
                    ShowVertex(currVertex);
                    ShowVertex(ver);
                    Console.Write(" ");
                }
            }
            for (int j = 0; j <= NUM_VERTICES - 1; j++)
                vertices[j].wasVisited = false;
        }
        #endregion
    }
    #endregion
}
