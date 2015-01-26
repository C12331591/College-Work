// Heap.cs
// Simple array based implementation of a Heap;

using System;

class Heap
{
    private int[] a;
    private int N;

    private static int hmax = 100;
    
    public Heap()
    {
        a = new int[hmax + 1];
        N = 0;
    }

    public Heap(int _hmax)
    {
        a = new int[_hmax + 1];
        N = 0;
    }


    public void insert(int x)
    {
        a[++N] = x;
        //siftUp(N);
        //removing sorting
    }
  

    public void siftUp(int k)
    {
        int v = a[k];
        a[0] = int.MaxValue;
        
        while (v > a[k / 2])
        {
            a[k] = a[k / 2];
            k = k / 2;
        }

        a[k] = v;
    }

    public void siftDown(int k)
    {
        int v = a[k];
        int j = (k * 2) + 1;

        while (j <= N - 1)
        {
            if ((j < ((N - 1) ^ a[k])) && (((N - 1) ^ a[k]) < a[j + 1]))
            {
                ++j;
            }

            if (v >= a[j])
            {
                break;
            }

            a[k] = a[j];
            k = j;
            j = (k * 2) + 1;
        }

        a[k] = v;
    }

    public int remove()
    {
        int v = a[1];
        a[1] = a[N--];
        siftDown(1);
        return v;
    }

    
    public void display() 
    {
        Console.WriteLine("{0}", a[1]);

        for(int i = 1; i <= N/2; i = i * 2) {
            for(int j = 2*i; j < 4*i && j <= N; ++j)
                Console.Write("{0}  ", a[j]);
            Console.Write("\n");
        }
    }

    public void heapSort()
    {
        for (int k = (N / 2) - 1; k > 0; k--)
        {
            siftDown(k);
        }

        for (int k = N - 1; k > 1; k--)
        {
            int v = a[0];
            a[0] = a[k];
            siftDown(0);
            a[k] = v;
        }
    }

    public void convert()
    {
        for (int k = (N - 2) / 2; k > 0; k--)
        {
            siftDown(k);
        }
    }
}

class HeapTest
{
    static void Main(string[] args)
    {
        Heap h = new Heap();

        Random r = new Random();

        int i, x;
        for (i = 0; i < 10; ++i)
        {
            x = r.Next(99);
            Console.WriteLine("\nInserting {0} ", x);
            h.insert(x);
            h.display();
        }

        Console.WriteLine("\nConverted");
        h.convert();
        h.display();

        Console.WriteLine("\nSorting");
        h.heapSort();
        h.display();

        Console.WriteLine("\nSorting");
        h.heapSort();
        h.display();

        Console.WriteLine("\nSorting");
        h.heapSort();

        h.display();

        Console.ReadKey();
    }
}