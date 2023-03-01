namespace SurprisesWithMutableStructures;

/// <summary>
/// Shows scenarios that demonstrate how using mutable structs can give unexpected results.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        AccessACopy();
        UsingArrays();
        AccessStructViaGetter();
        ListIndexer();
        AccessReadonlyStructs();
        BoxingUnboxing();
        AccessStructViaInterface();
        AccessStructViaReadOnlyMember();
    }

    private static void AccessACopy()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("StructCopy");

        Counter c1 = new Counter();

        // The next portion works as expected.
        Console.WriteLine(c1.Increment());
        Console.WriteLine(c1.Increment());
        Console.WriteLine(c1.Increment());

        Counter c2 = c1;

        // Changing c2 does not change c1. That is pretty obvious since c2 is a copy of c1.
        // All other cases throughout the rest of the code are based on the same type of process.
        // It the other cases however, the fact that you will operate on a copy of some original structure
        // is not quite so obvious.

        Console.WriteLine(c2.Increment());
        Console.WriteLine(c2.Increment());
        Console.WriteLine(c1.GetCounter());
    }

    private static void UsingArrays()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("ArrayScenario");

        Counter[] counterArray = new Counter[1];

        // The next portion works as expected.
        Console.WriteLine(counterArray[0].Increment());
        Console.WriteLine(counterArray[0].Increment());
        Console.WriteLine(counterArray[0].Increment());

        // The next portion may surprise you.
        Counter c1 = counterArray[0];
        Console.WriteLine(c1.Increment());
        Console.WriteLine(c1.Increment());
        Console.WriteLine(counterArray[0].GetCounter());
    }

    private static void AccessStructViaGetter()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("AccessStructViaGetter");

        CounterWrapper counterWrapper = new CounterWrapper();

        // The next portion may surprise you.
        Console.WriteLine(counterWrapper.Counter.Increment());
        Console.WriteLine(counterWrapper.Counter.Increment());
        Console.WriteLine(counterWrapper.Counter.Increment());

    }

    private static void ListIndexer()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("ListIndexer");

        List<Counter> counterList = new List<Counter>() { new Counter() };

        // The next portion may surprise you.
        // This is the same scenario as in AccessStructViaGetter. The indexer
        // of List works like a property (is in fact a parameterized property).
        Console.WriteLine(counterList[0].Increment());
        Console.WriteLine(counterList[0].Increment());
        Console.WriteLine(counterList[0].Increment());
    }

    private static void AccessReadonlyStructs()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("AccessReadonlyStructs");

        CounterWrapperWithReadOnlyField counterWrapper = new CounterWrapperWithReadOnlyField();

        // The next portion may surprise you.
        Console.WriteLine(counterWrapper.Counter.Increment());
        Console.WriteLine(counterWrapper.Counter.Increment());
        Console.WriteLine(counterWrapper.Counter.Increment());
    }

    private static void BoxingUnboxing()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("BoxingUnboxing");

        Counter counter = new Counter();

        Console.WriteLine(counter.Increment());
        Object obj = counter;
        Console.WriteLine(((Counter)obj).GetCounter());

        // The next portion may surprise you.
        ((Counter)obj).Increment();
        Console.WriteLine(((Counter)obj).GetCounter());
    }

    private static void AccessStructViaInterface()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("AccessStructViaInterface");

        IntChanger intChanger = new IntChanger();

        intChanger.Change(10);
        Console.WriteLine(intChanger.GetValue());

        // The next portion may surprise you.
        ((IChangeValue)intChanger).Change(20);
        Console.WriteLine(intChanger.GetValue());
    }

    private static void AccessStructViaReadOnlyMember()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("AccessStructViaReadOnlyMember");

        CounterWrapperWithField c1 = new CounterWrapperWithField();
        c1.Counter.Increment();
        Console.WriteLine(c1.Counter.GetCounter());

        c1.Counter.Increment();
        Console.WriteLine(c1.Counter.GetCounter());

        c1.Counter.Increment();
        Console.WriteLine(c1.Counter.GetCounter());

        // The next portion may surprise you.

        CounterWrapperWithReadOnlyField c2 = new CounterWrapperWithReadOnlyField();
        c2.Counter.Increment();
        Console.WriteLine(c2.Counter.GetCounter());

        c2.Counter.Increment();
        Console.WriteLine(c2.Counter.GetCounter());

        c2.Counter.Increment();
        Console.WriteLine(c2.Counter.GetCounter());
    }

    private static void CompilerError()
    {
        CounterWrapperWithPublicProperty counterWrapper = new CounterWrapperWithPublicProperty();

        // Uncomment the next line to see a compiler error.
        // Simply accessing counterWrapper.Counter will generate a copy of Counter. That copy however
        // is not accessible since you are not assigning the copy to any variable. In other words, you are
        // attempting to mutate a copy of counterWrapper.Counter that is not accessible and the compiler
        // realize that's very likely not what you want.
        // counterWrapper.Counter.counterValue++;

        // This will work fine.
        CounterWithPublicField c1 = counterWrapper.Counter;
        c1.CounterValue++;
    }
}

public struct Counter
{
    private int _counterValue;

    public int Increment()
    {
        _counterValue++;
        return _counterValue;
    }

    public void Reset()
    {
        _counterValue = 0;
    }

    public int GetCounter()
    {
        return _counterValue;
    }
}

public class CounterWrapper
{
    public Counter Counter { get; set; }
}

public class CounterWrapperWithField
{
    public Counter Counter;

    public void Reset()
    {
        // Note that this will not generate a compiler error although Counter is declared read-only. 
        // The compiler does not know that Counter.Reset mutates the Counter struct.
        Counter.Reset();

        // Note that the next line would generate a compiler error even if _counterValue was public 
        // Counter._counterValue = 100;
    }
}

public class CounterWrapperWithReadOnlyField
{
    public readonly Counter Counter;

    public void Reset()
    {
        // Note that this will not generate a compiler error although Counter is declared read-only. 
        // The compiler does not know that Counter.Reset mutates the Counter struct.
        Counter.Reset();

        // Note that the next line would generate a compiler error even if _counterValue was public 
        // Counter._counterValue = 100;
    }
}

public struct CounterWithPublicField
{
    public int CounterValue;
}

public class CounterWrapperWithPublicProperty
{
    public CounterWithPublicField Counter { get; set; }
}

public interface IChangeValue
{
    void Change(int i);
}

public struct IntChanger : IChangeValue
{
    private int _intValue;

    public void Change(int i)
    {
        _intValue = i;
    }

    public int GetValue()
    {
        return _intValue; ;
    }
}