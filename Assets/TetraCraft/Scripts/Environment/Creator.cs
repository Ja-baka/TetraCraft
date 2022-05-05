using UnityEngine;

public abstract class Creator<T> : MonoBehaviour
{
    public T[] GetCollection()
    {
        return (T[])FillArray().Clone();
    }

    public T PickRandom()
    {
        T[] Collection = FillArray();
        int index = Random.Range(0, Collection.Length);
        return Collection[index];
    }

    protected abstract T[] FillArray();
}
