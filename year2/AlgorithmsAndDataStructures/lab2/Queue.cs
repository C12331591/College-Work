// Queue.cs
// Linked list implementation of Queue

using System;

class Queue {

    class Node {
        public int data;
        public Node next;
    }

    private Node z;
    private Node head;
    private Node tail;

    public Queue() {
        z = new Node();
        z.next = z;
        head = z;
        tail = null;
    }


    public void display() {
        Console.Write("\nThe queue values are:\n");

        Node temp = head;
        while( temp != temp.next) {
            Console.Write("{0}  ", temp.data);
            temp = temp.next;
        }
        Console.Write("\n\n");
    }



    public void enQueue( int x) {
        Node  temp;

        temp = new Node();
        temp.data = x;
        temp.next = z;

        if (tail == null)  // case of empty list
        {
            head = temp;
        }
        else              // case of list not empty
        {
            tail.next = temp;
        }

        tail = temp;      // new node is now at the tail
    }


    // assume the queue is non-empty when this method is called
    // In general, an exception should be thrown if this is not so.
    // deQueue()
    public int deQueue()
    {
        int deQueued = head.data;
        head = head.next;
        return deQueued;
    }
 


    public bool isEmpty() {
        return head == head.next;
    }

}

class QueueTest
{
    // try out the ADT Queue using static allocation
    public static void Main() {

       Queue q = new Queue();

       Console.Write("Inserting ints from 9 to 1 into queue gives:\n");
       for (int i = 9; i > 0; --i) {
          q.enQueue( i);
       }

       q.display();

       if (!q.isEmpty())
       {
           Console.Write("Deleting value {0} from front of queue", q.deQueue());
       }

       Console.Write("\nAdding value {0} to back of queue", 27);
       q.enQueue(27);
       q.display();
       
    }
}
