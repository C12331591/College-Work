// Sorted linked list with no sentinel node
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

    private Node head;

    public SortedLL()
    {
        head = new Node();
        head.next = null;
    }
    
    // this is the crucial method
    public void insert(int x)
    {
        Node prev, curr, t;
        t = new Node();
        t.data = x;
               
        // write code to insert x into sorted list

        curr = head;
        prev = new Node();

        if (curr == prev)//if the list is empty
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
            while (curr != null)
            {
                if (t.data >= curr.data && curr.next == null)
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
        while( t != null) {
            Console.Write(t.data);
            t = t.next;
            if (t != null)
            {
                Console.Write(" -> ");
            }
            else
            {
                Console.Write("\n");
            }
        }
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