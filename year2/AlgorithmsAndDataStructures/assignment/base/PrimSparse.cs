// Prim's MST Algorithm on Adjacency Lists representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs
// PrimSparse.cs

using System;
using System.IO;

// Heap code to be adapted for Prim's algorithm
// on adjacency lists graph
class Heap
{
    private int[] h;	   // heap array
    private int[] hPos;	   // hPos[h[k]] == k
    private int[] dist;    // dist[v] = priority of v

    private int N;         // heap size
   
    // The heap constructor gets passed from the Graph:
    //    1. maximum heap size
    //    2. reference to the dist[] array
    //    3. reference to the hPos[] array
    public Heap(int maxSize, int[] _dist, int[] _hPos) 
    {
        N = 0;
        h = new int[maxSize + 1];
        dist = _dist;
        hPos = _hPos;
    }


    public bool isEmpty() 
    {
        return N == 0;
    }

    
    public void siftUp( int k) 
    {
        int v = h[k];

        h[0] = 0;  // put dummy vertes before top of heap
        dist[0] = int.MinValue;

        while( ) {
            // missing code
        }
        // missing code       
    }


    public void siftDown( int k) 
    {
        int v, j;
       
        // missing code

    }

    public void insert( int x) 
    {
        h[++N] = x;
        siftUp( N);
    }


    public int remove() 
    {   
        int v = h[1];
        hPos[v] = 0; // v is no longer in heap
        h[N+1] = 0;  // put null node into empty spot
        
        h[1] = h[N--];
        siftDown(1);
        
        return v;
    }
}  // end of Heap class


// Graph code to support Prim's MSt Alg
class Graph 
{
    
    // Same as in GraphLists.cs which had DF traversal
    // If you did that, just copy and paste attributes code      
    
    
    // default constructor
    public Graph(string graphFile)  
    {
        // same as in GraphLists.cs which had DF traversal
        // If you did that, just copy and paste constructor code
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
	{  
        return (char)(u + 64);
    }
    
    // method to display the graph representation
    // same as before


    
   

    // Prim's algorithm to compute MST
    // Code most of this yourself
    int[] MST_Prim( int s) 
    {
        int v, u;
        int wgt, wgt_sum = 0;
        int[]  dist, parent, hPos;
        Node t;
        
        // code here
        dist[s] = 0;
        
        // code here
        
        while ( ! pq.isEmpty())  
        {
            // code here
            Console.Write("\nAdding to MST edge {0}--({1})--{2}", toChar(parent[v]), dist[v], toChar(v));
            // more code here
            
        }
        Console.Write("\n\nWeight of MST = {0}\n",wgt_sum);
               
        return parent;
    }


    public void showMST(int[] mst)
    {
            Console.Write("\n\nMinimum Spanning tree parent array is:\n");
            for(int v = 1; v <= V; ++v)
                Console.Write("{0} -> {1}\n", toChar(v), toChar(mst[v]));
            Console.WriteLine("");
    }
 
 
    public static void Main()
    {
        int s = 4;
        int[] mst;
        string fname = "wGraph3.txt";               

        Graph g = new Graph(fname);
       
        //g.display();
        
        //mst = g.MST_Prim(s);
        
        //g.showMST(mst);
    }

} // end of Graph class


