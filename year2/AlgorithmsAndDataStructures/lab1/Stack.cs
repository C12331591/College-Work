// Stack.cs
// Partial linked list implementation of Stack

using System;

class Stack {
    
    class Node {
        public int data;
        public Node next;  
    }
    private Node top;
      
    public Stack()
    { 
        top = null;
    }
        
    public void push(int x) {
        Node  t = new Node();
        t.data = x;
        t.next = top;
        top = t;
    }

    public int pop()
    {
        int popped = top.data;
        top = top.next;
        return popped;
    }

    
    public bool isEmpty(){
        return top == null;
    }

    public bool isMember(int x)
    {
        Node t = top;

        while (t != null)
        {
            if (x == t.data)
            {
                return true;
            }

            t = t.next;
        }

        return false;
    }


    public void display() {
        Node t = top;
        Console.Write("\nStack contents are:  ");
    
        while (t != null) {
            Console.Write("{0} ", t.data);
            t = t.next;
        }
        Console.Write("\n");
    }
}

class StackTest
{

    public static void Main()
    {
        Stack s = new Stack();
        Console.Write("Stack is created\n");
        
        s.push(10); s.push(3); s.push(11); s.push(7);
        s.display();
        
        int i = s.pop();
        Console.Write("\nJust popped {0}", i);
        s.display();

        int[] search = { 2, 3 };

        foreach(int cur in search)
        {
            if (s.isMember(cur))
            {
                Console.Write("\n{0} is in the stack", cur);
            }
            else
            {
                Console.Write("\n{0} is not in the stack", cur);
            }
        }
    }
}

