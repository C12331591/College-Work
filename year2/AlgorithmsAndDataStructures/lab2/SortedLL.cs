// Sorted linked list with a sentinel node
// Skeleton code
using System;

class SortedLL
{
    // internal data structure and
    // constructor code to be added here
    class Node
    {
        public int data;
        public Node next;
    }

    private Node z;
    private Node head;

    public SortedLL()
    {
        z = new Node();
        z.next = z;
        head = z;
    }
    
    // this is the crucial method
    public void insert(int x)
    {
        Node prev, curr, t;
        t = new Node();
        t.data = x;
        t.next = z;
               
        // write code to insert x into sorted list

        curr = head;
        prev = z;

        if (curr == z && prev == z)//if the list is empty
        {
            head = t;
        }
        else if (t.data <= head.data)//if the value being inserted comes first
        {
            t.next = head;
            head = t;
        }
        else
        {
            while (curr != z)
            {
                if (t.data >= curr.data && curr.next == z)
                {
                    curr.next = t;
                    return;
                }
                else if (t.data <= curr.data && t.data >= prev.data)
                {
                    t.next = curr;
                    prev.next = t;
                    return;
                }

                prev = curr;
                curr = curr.next;
            }
        }
    }    

    public void display()
    {
        Node t = head;
        Console.Write("\nHead -> ");
        while( t != z) {
            Console.Write("{0} -> ", t.data);
            t = t.next;
        }
        Console.Write("Z\n");
    }
    
    public static void Main()
    {
        SortedLL list = new SortedLL();
        list.display();
        
        int i, x;
        Random r = new Random();
        
        for(i=0; i<10; ++i) {
            x = r.Next(20);
            list.insert(x);
            Console.Write("\nInserting {0}", x);
            list.display();            
        }
        Console.ReadKey();
    }
}