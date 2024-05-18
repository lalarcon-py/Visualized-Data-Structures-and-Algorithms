namespace DataStructureVisualizer.DataStructures;

public class Stack<T>
{
    private List<T> items = new List<T>();

    public void Push(T item) => items.Add(item);

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        var item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public IEnumerable<T> GetItemsInReverse()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            yield return items[i];
        }
    }
}