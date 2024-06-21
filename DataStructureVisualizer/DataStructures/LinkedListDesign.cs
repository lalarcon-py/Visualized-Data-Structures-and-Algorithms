namespace DataStructureVisualizer.DataStructures;

public class LinkedListDesign<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
    }

    private Node head;
    private Node tail;
    private int count;
    
    public bool Remove(T item)
    {
        if (head == null)
            return false;

        if (head.Value.Equals(item))
        {
            head = head.Next;
            if (head == null)
                tail = null;
            count--;
            return true;
        }

        var current = head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                    tail = current;
                count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void AddFirst(T item)
    {
        var node = new Node { Value = item };
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head = node;
        }
        count++;
    }

    public void AddLast(T item)
    {
        var node = new Node { Value = item };
        if (tail == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }
        count++;
    }

    public bool RemoveFirst()
    {
        if (head == null)
            return false;

        head = head.Next;
        if (head == null)
            tail = null;

        count--;
        return true;
    }

    public bool RemoveLast()
    {
        if (tail == null)
            return false;

        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            var current = head;
            while (current.Next != tail)
                current = current.Next;

            current.Next = null;
            tail = current;
        }

        count--;
        return true;
    }
    
    public T GetLast()
    {
        if (tail == null)
            throw new InvalidOperationException("Linked list is empty.");

        return tail.Value;
    }
    
    public T GetFirst()
    {
        if (head == null)
            throw new InvalidOperationException("Linked list is empty.");

        return head.Value;
    }

    public T GetElementAt(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        var current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }

    public bool Contains(T item)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;

            current = current.Next;
        }
        return false;
    }

    public int Count => count;

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
}