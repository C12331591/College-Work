// Stack.cs
// Partial array implementation of Stack

using System;

class Stack {
    
    int[] stack;
      
    public Stack()
    { 
        stack = new int[0];
    }
        
    public void push(int x) {
        int[] prev = stack;
        stack = new int[stack.Length + 1];
        Array.Copy(prev, stack, prev.Length);
        stack[prev.Length] = x;//length of the previous version of the stack is the same as the location of the final element in the new one
    }

    public int pop()
    {
        int[] prev = stack;
        stack = new int[stack.Length - 1];
        Array.Copy(prev, stack, stack.Length);
        return (prev[stack.Length]);
    }

    
    public bool isEmpty(){
        stack = new int[0];
        return true;
    }

    public bool isMember(int x)
    {
        foreach (int cur in stack)
        {
            if (cur == x)
            {
                return true;
            }
        }

        return false;
    }


    public void display() {
        Console.Write("\nStack contents are:  ");

        for (int i = stack.Length - 1; i > -1; i--)
        {
            Console.Write("{0} ", stack[i]);
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

