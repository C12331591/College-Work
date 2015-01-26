// Kruskal's Minimum Spanning Tree Algorithm
// Union-find implemented using disjoint set trees

using System;
using System.IO;

// convert vertex into char for pretty printing

class Edge
{
    public int u, wgt, v;//the three components of the edge

    public void show()
    {
        Console.Write("Edge {0}-{1}-{2}\n", toChar(u), wgt, toChar(v));
    }

    public override string ToString()
    {
        return u.ToString() + "-" + wgt.ToString() + "-" + v.ToString();
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
    {
        return (char)(u + 64);
    }

    public Edge(int U, int V, int Wgt)
    {
        u = U;
        wgt = Wgt;
        v = V;
    }

    public Edge()//default constructor
        : this(0, 0, 0)
    {
    }

    //operator overloading
    public static bool operator ==(Edge a, Edge b)
    {
        return a.wgt == b.wgt;
    }

    public static bool operator !=(Edge a, Edge b)
    {
        return !(a == b);
    }

    public static bool operator >(Edge a, Edge b)
    {
        return a.wgt > b.wgt;
    }

    public static bool operator <(Edge a, Edge b)
    {
        return a.wgt < b.wgt;
    }

    public static bool operator >=(Edge a, Edge b)
    {
        return (a > b || a == b);
    }

    public static bool operator <=(Edge a, Edge b)
    {
        return (a < b || a == b);
    }
}


class Heap//heap goes unused in this implementation
{
    private int[] h;
    int N, Nmax;
    Edge[] edge;


    // Bottom up heap constructor
    public Heap(int _N, Edge[] _edge)
    {
        int i;
        Nmax = N = _N;
        h = new int[N + 1];
        edge = _edge;

        // initially just fill heap array with 
        // indices of edge[] array.
        for (i = 0; i <= N; ++i)
            h[i] = i;

        // Then convert h[] into a heap
        // from the bottom up.
        for (i = N / 2; i > 0; --i)
            siftDown(i);
    }




    private void siftDown(int k)
    {

    }


    public int remove()
    {
        h[0] = h[1];
        h[1] = h[N--];
        siftDown(1);
        return h[0];
    }
}

/****************************************************
*
*       UnionFind partition to support union-find operations
*       Implemented simply using Discrete Set Trees
*
*****************************************************/

class UnionFindSets
{
    private int[] treeParent;//contains the number of the set each vertex belongs to
    private int N;//number of vertices

    public UnionFindSets(int V)//constructor - it is passed the number of vertices
    {
        treeParent = new int[V + 1];

        for (int i = 0; i <= V; i++)
        {
            treeParent[i] = i;//at the start, each vertex belongs to its own set
        }

        N = V + 1;//iterating through treeParent starts at 1, so its actual length is V + 1
    }

    public int findSet(int vertex)//returns the set the specified vertex belongs to
    {
        return treeParent[vertex];
    }

    public void union(int set1, int set2)//unions the two specified sets
    {
        for (int i = 1; i < N; i++)
        {
            if (treeParent[i] == set2)
            {
                treeParent[i] = set1;//if the current vertex belongs to set 2, put it into set1
            }
        }
    }

    public void unionByEdge(Edge e)//this is a handy way to union the sets of the two vertices in an edge
    {
        union(treeParent[e.u], treeParent[e.v]);
    }

    public void showTrees()//unused
    {
        int i;
        for (i = 1; i < N; ++i)
            Console.Write("{0}->{1}  ", toChar(i), toChar(treeParent[i]));
        Console.Write("\n");
    }

    public void showSets()//shows each set and the members of each
    {
        Console.Write("\n");

        for (int i = 1; i < N; i++)
        {
            Console.Write("\n{0}: ", i);
            showSet(i);
        }
    }

    private void showSet(int root)//shows all the members of the specified set
    {
        for (int i = 1; i < N; i++)
        {
            if (treeParent[i] == root)//if the current vertex is a member of the current set
            {
                Console.Write("{0} ", i);
            }
        }
    }

    private char toChar(int u)
    {
        return (char)(u + 64);
    }

    public bool valid(Edge check)//this checks to see if the vertices of the edge belong to different sets. If they do, the edge won't make a cycle in the mst, so it is valid
    {
        return treeParent[check.u] != treeParent[check.v];
    }

    public bool spanning()//checks to see if a spanning tree has been formed
    {
        for (int i = 1; i < N; i++)
        {
            if (treeParent[i] != treeParent[1])//they will all have the same parent when it is a spanning tree
            {
                return false;
            }
        }

        return true;
    }
}

class Graph
{
    private int V, E;//number of vertices and edges
    private Edge[] edge;//all edges
    private Edge[] mst;//edges in minimum spanning tree

    public Graph(string graphFile)
    {
        int u, v;
        int w, e;

        StreamReader reader = new StreamReader(graphFile);

        char[] splits = new char[] { ' ', ',', '\t' };
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);

        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);


        // create edge array

        edge = new Edge[E + 1];

        // read the edges
        Console.WriteLine("Reading edges from text file");

        edge[0] = new Edge();
        
        for (e = 1; e <= E; ++e)
        {
            line = reader.ReadLine();
            parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            u = int.Parse(parts[0]);
            v = int.Parse(parts[1]);
            w = int.Parse(parts[2]);

            Console.WriteLine("Edge {0}--({1})--{2}", toChar(u), w, toChar(v));

            edge[e] = new Edge(u, v, w);//making an edge from the data in a line
        }
    }


    /**********************************************************
    *
    *       Kruskal's minimum spanning tree algorithm
    *
    **********************************************************/
    public Edge[] MST_Kruskal()
    {
        int ei, i = 0;//i tracks the current position in the mst array
        Edge e;
        int uSet, vSet;//unused
        UnionFindSets partition;

        // create edge array to store MST
        // Initially it has no edges.
        mst = new Edge[V - 1];

        // priority queue for indices of array of edges

        Edge[] sorted = sortEdges();

        // create partition of singleton sets for the vertices

        partition = new UnionFindSets(V);

        partition.showSets();//at this point, each vertex will be in its own set

        foreach (Edge cur in sorted)
        {
            if (partition.valid(cur))//if the current edge wouldn't create a cycle
            {
                mst[i++] = cur;//add the edge to the mst
                partition.unionByEdge(cur);//union the sets of the two vertices in the current edge
            }

            if (partition.spanning())//if a spanning tree has been formed, the work is complete
            {
                break;
            }
        }

        partition.showSets();//all the vertices will now be in the same set

        return mst;
    }

    private Edge[] sortEdges()//this creates a second array before calling quicksort
    {
        Edge[] sorted = new Edge[edge.Length];

        //initialisation of the sorted array
        for (int i = 0; i < edge.Length; i++)
        {
            sorted[i] = new Edge();
        }

        for (int i = 0; i < edge.Length; i++)
        {
            sorted[i].u = edge[i].u;//this is done step by step to avoid having them both reference the same object
            sorted[i].v = edge[i].v;
            sorted[i].wgt = edge[i].wgt;
        }

        quickSort(sorted, 0, edge.Length - 1);

        return sorted;
    }

    private void quickSort(Edge[] edges, int l, int r)//an implementation of the quicksort algorithm, made to work with edges
    {
        int j;

        if (l < r)//while the partitions contain more than one element
        {
            j = partition(edges, l, r);//j marks the splitting point
            quickSort(edges, l, j - 1);//sorting the partitions
            quickSort(edges, j + 1, r);
        }
    }

    private int partition(Edge[] a, int l, int r)//component of quicksort
    {
        Edge pivot, temp;
        int i, j;

        pivot = a[l];
        i = l;
        j = r + 1;

        while (true)
        {
            do { ++i; } while (a[i] <= pivot && i < r);
            do { --j; } while (a[j] > pivot);

            if (i >= j)
            {
                break;
            }

            temp = a[i];//swapping
            a[i] = a[j];
            a[j] = temp;
        }

        temp = a[l];
        a[l] = a[j];
        a[j] = temp;

        return j;
    }

    // convert vertex into char for pretty printing
    private char toChar(int u)
    {
        return (char)(u + 64);
    }

    public void showMST()//shows edges in the minimum spanning tree
    {
        Console.Write("\nMinimum spanning tree build from following edges:\n");
        for (int e = 0; e < V - 1; ++e)
        {
            mst[e].show();
        }
        Console.WriteLine();

    }

    // test code
    public static int Main()
    {
        string fname = "wGraph3.txt";
        Console.Write("\nInput name of file with graph definition: ");
        fname = Console.ReadLine();

        Graph g = new Graph(fname);

        g.MST_Kruskal();

        g.showMST();

        Console.ReadKey();//keeping the window open

        return 0;
    }

} // end of Graph class
