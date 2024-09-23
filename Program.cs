using System;
using System.Collections;
using System.Diagnostics;

namespace HomeWork_Basic_02;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Home work 2 ---");

        var listOfInt = new List<int>(1000000);
        var arrayListOfInt = new ArrayList(1000000);
        var linkedListOfInt = new LinkedList<int>();
        Console.WriteLine("\n1) Time to fill ");
        Console.WriteLine($"  - List:\t{TimeToFillingCollection(listOfInt)} ms");
        Console.WriteLine($"  - ArrayList:\t{TimeToFillingCollection(arrayListOfInt)} ms");
        Console.WriteLine($"  - LinkedList:\t{TimeToFillingCollection(linkedListOfInt)} ms");
        WaitingToPressedEnter();

        Console.WriteLine("\n2) Finding an element in a collection");
        var element = listOfInt[496753];
        Console.WriteLine($"  - List:\t{TimeSearchingOperation(listOfInt, element)} ms");
        Console.WriteLine($"  - ArrayList:\t{TimeSearchingOperation(arrayListOfInt, element)} ms");
        Console.WriteLine($"  - LinkedList:\t{TimeSearchingOperation(linkedListOfInt, element)} ms");
        WaitingToPressedEnter();

        Console.WriteLine("\n3) Dividing operation time");
        long[] timeOperation = new long[3];
        timeOperation[0] = TimeDividingOperation(listOfInt, 777);
        Console.WriteLine($"Operation execution time for List: {timeOperation[0]} ms");
        WaitingToPressedEnter();

        timeOperation[1] = TimeDividingOperation(arrayListOfInt, 777);
        Console.WriteLine($"Operation execution time for ArrayList: {timeOperation[1]} ms");
        WaitingToPressedEnter();

        timeOperation[2] = TimeDividingOperation(linkedListOfInt, 777);
        Console.WriteLine($"Operation execution time for LinkedList: {timeOperation[2]} ms");
        WaitingToPressedEnter();

        Console.Write(
            $"  \n3) Division operation time" +
            $"  \n  - List:\t{timeOperation[0]} ms" +
            $"  \n  - ArrayList:\t{timeOperation[1]} ms" +
            $"  \n  - LinkedList:\t{timeOperation[2]} ms\n\n");       
    }

    static void WaitingToPressedEnter()
    {
        Console.WriteLine("To continue, press Enter");
        Console.ReadLine();
    }

    static long TimeSearchingOperationCollection(ICollection collection, int element)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach(var c in collection)
        {
            if (c.Equals(element))
                break;
        }        
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeSearchingOperation(List<int> listOfInt, int element)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < listOfInt.Count; i++)
        {
            if (listOfInt[i] == element)
                break;
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeSearchingOperation(ArrayList arrayList, int element)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < arrayList.Count; i++)
        {
            if ((int?)arrayList[i] == element)
                break;
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeSearchingOperation(LinkedList<int> linkedList, int element)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var currentNode = linkedList.First;
        for (int i = 0; i < linkedList.Count; i++)
        {
            if(currentNode?.Value == element)
                break;
            currentNode = currentNode?.Next;
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeToFillingCollection(List<int> listOfInts)
    {
        var stopwatch = new Stopwatch();
        var rand = new Random(100);
        stopwatch.Start();
        for (int i = 0; i < 1000000; i++)
            listOfInts.Add(rand.Next(1000001));
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeToFillingCollection(ArrayList arrayList)
    {
        var stopwatch = new Stopwatch();
        var rand = new Random(100);
        stopwatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            arrayList.Add(rand.Next(1000001));
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeToFillingCollection(LinkedList<int> linkedList)
    {
        var stopwatch = new Stopwatch();
        var rand = new Random(100);
        stopwatch.Start();
        stopwatch.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            linkedList.AddLast(rand.Next(1000001));
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long TimeDividingOperation(ICollection collection, int div)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Restart();
        foreach (var element in collection)
        {
            if ((int)element % div == 0)
                Console.WriteLine(element);
        }
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
