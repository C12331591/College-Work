// Simple weighted graph representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs

using System;
using System.IO;

class Graph 
{
    // class for linked list nodes needed, do yourself
    public class Node
    {
        public int vert;
        public int wgt;
        public Node next;

        public Node()
        {
            vert = 0;
            wgt = 0;
            next = null;
        }

        public Node(int Vert, int Wgt, Node Next)
        {
            vert = Vert;
            wgt = Wgt;
            next = Next;
        }

        public override string ToString()
        {
            string formatted = vert + " - " + wgt + " - " + next.vert;
            return formatted;
        }
    }

    public class Stack
    {
        public Node head;
        public Node z;

        public Stack()
        {
            z = new Node();
            
            head = z;
        }

        public void push(int v)
        {
            Node newHead = new Node(v, 0, head);

            head = newHead;
        }

        public int pop()
        {
            int ret = head.vert;
            head = head.next;
            return ret;
        }

        public bool isEmpty()
        {
            if (head == z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    // Declare te following
    // V = number of vertices
    // E = number of edges
    // adj[] is the adjacency lists array
    private int V, E;
    private Node[] adj;
    
	// missing declaration here
	
    private Node z;
    
    // used for traversing graph
    private int[] visited;
    private int id;
    
    
    // default constructor, some code missing
    public Graph(string graphFile)  
    {
        int u, v;
        int e, wgt;
        Node t;

        StreamReader reader = new StreamReader(graphFile);
	   
	    char[] splits = new char[] { ' ', ',', '\t'};     
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
        
        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);

        // create sentinel node
        z = new Node(); 
        z.next = z;
        
        // Create adjacency lists, initialised to sentinel node z
        // Dynamically allocate array 
        // adj = ????
        adj = new Node[V + 1];

        for (v = 1; v <= V; ++v)
        {
            adj[v] = z;
        }
        
        // read the edges
		Console.WriteLine("Reading edges from text file");
	    for(e = 1; e <= E; ++e)
	    {
            line = reader.ReadLine();
            parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            u = int.Parse(parts[0]);
            v = int.Parse(parts[1]); 
            wgt = int.Parse(parts[2]);
            
            Console.WriteLine("Edge {0}--({1})--{2}", toChar(u), wgt, toChar(v));    
            // write code to put edge into adjacency lists
            Insert(u, v, wgt);
            Insert(v, u, wgt);
            
			// do yourself
	    }
    }

    private void Insert(int pos, int v, int wgt)
    {
        Node cur = adj[pos];
        Node ins = new Node(v, wgt, cur);
        Console.WriteLine(ins);

        if (cur == cur.next)//if it's the first edge from this vertex
        {
            adj[pos] = ins;
        }
        else if (cur.vert < v)//if the edge being inserted is the lowest
        {
            adj[pos] = ins;
        }
        else
        {
            ins.next = cur.next;

            while (cur != z)
            {
                if (cur.vert > v && cur.next.vert < v)
                {
                    cur.next = ins;
                }
                else if (cur.next == z && cur.vert > v)
                {
                    cur.next = ins;
                }

                cur = cur.next;
                ins.next = cur.next;
            }
        }
    }

    public void DF(int s)
    {
        id = 0;
        visited = new int[V + 1];

        for (int v = 1; v < V + 1; ++v)
        {
            visited[v] = 0;
        }

        dfVisit(0, s);
    }

    private void dfVisit(int prev, int v)
    {
        int u;

        visited[v] = ++id;

        Console.WriteLine("Visited vertex {0} along edge {1} - {0}", v, prev);

        //for (u = 1; u < adj.GetLength(1); ++u)
        Node cur = adj[v];

        while (cur != z)
        {
            u = cur.vert;

            if (visited[u] == 0)
            {
                dfVisit(v, u);
            }

            cur = cur.next;
        }
    }

    public void iterativeDF(int s)
    {
        Stack S = new Stack();
        
        id = 0;

        for (int v = 1; v < V + 1; ++v)
        {
            visited[v] = 0;
        }

        S.push(s);

        int prev = 0;

        while (!S.isEmpty())
        {
            int v = S.pop();

            if (visited[v] == 0)
            {
                visited[v] = ++id;
                Console.WriteLine("Visited vertex {0} along edge {1} - {0}", v, prev);

                Node cur = adj[v];

                while (cur != z)
                {
                    int u = cur.vert;

                    if (visited[u] == 0)
                    {
                        S.push(u);
                    }

                    prev = v;
                    cur = cur.next;
                }
            }
        }
    }
   
    // convert vertex into char for pretty printing
    private char toChar(int u)
    {  
        return (char)(u + 64);
    }
    
    // method to display the graph representation
    public void display() {
        int v;
        Node n;
        
        for(v=1; v<=V; ++v){
            Console.Write("\nadj[{0}] ->", toChar(v));
            for(n = adj[v]; n != z; n = n.next) 
                Console.Write(" |{0} | {1}| ->", toChar(n.vert), n.wgt);
            Console.WriteLine(" z");
        }            
    }


    


    public static void Main()
    {
        int s = 1;
        string fname = "wGraph3.txt";               

        Graph g = new Graph(fname);
       
        g.display();
        
        g.DF(s);

        Console.WriteLine();

        g.iterativeDF(s);

        fname = "wGraph2.txt";
        g = new Graph(fname);

        g.display();

        g.DF(s);

        Console.WriteLine();

        g.iterativeDF(s);
    }

}

