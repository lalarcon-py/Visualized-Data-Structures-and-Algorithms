using System.Collections;

namespace DataStructureVisualizer.DataStructures;

public class Queue<T> : IEnumerable
{
    private readonly LinkedList<T> items = new LinkedList<T>();

    public void Enqueue(T item)
    {
        items.AddLast(item);
    }

    public T Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        var item = Peek();
        items.RemoveFirst();
        return item;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty");

        var first = items.GetEnumerator();
        first.MoveNext();
        return first.Current;
    }

    public int Count => items.Count;

    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}