using System.Collections.Generic;

namespace DataStructureVisualizer.DataStructures;

public class HashTable<TKey, TValue>
{
    private const int DefaultCapacity = 16;
    private readonly LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

    public HashTable()
    {
        buckets = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
        for (int i = 0; i < DefaultCapacity; i++)
        {
            buckets[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
        }
    }

    public void Add(TKey key, TValue value)
    {
        var bucket = GetBucket(key);
        var entry = new KeyValuePair<TKey, TValue>(key, value);
        bucket.AddLast(entry);
    }

    public bool Remove(TKey key)
    {
        var bucket = GetBucket(key);
        var current = bucket.GetEnumerator();
        while (current.MoveNext())
        {
            if (current.Current.Key.Equals(key))
            {
                return bucket.Remove(current.Current);
            }
        }
        return false;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var bucket = GetBucket(key);
        var current = bucket.GetEnumerator();
        while (current.MoveNext())
        {
            if (current.Current.Key.Equals(key))
            {
                value = current.Current.Value;
                return true;
            }
        }
        value = default;
        return false;
    }
    
    public LinkedList<KeyValuePair<TKey, TValue>>[] GetBuckets()
    {
        return buckets;
    }

    public bool ContainsKey(TKey key)
    {
        var bucket = GetBucket(key);
        var current = bucket.GetEnumerator();
        while (current.MoveNext())
        {
            if (current.Current.Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }

    private LinkedList<KeyValuePair<TKey, TValue>> GetBucket(TKey key)
    {
        var hashCode = key.GetHashCode();
        var index = Math.Abs(hashCode) % buckets.Length;
        return buckets[index];
    }
}