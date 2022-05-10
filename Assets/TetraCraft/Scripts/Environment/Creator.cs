using System.Linq;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [System.Serializable]
    private class Entry<T>
    {
        public T Item;
        [Range(0, 1)] public float Weight;
    }

    [SerializeField] private Entry<BlockMaterial>[] _entries;
    [SerializeField] private Shape[] _shapes;

    public Shape PickRandomShape()
    {
        int index = Random.Range(0, _shapes.Length);
        return _shapes[index];
    }

    public BlockMaterial PickRandomMaterial()
    {
        float totalWeight = _entries.Sum((x) => x.Weight);
        float random = Random.value;
        float rate = random * totalWeight;
        float currentWeight = 0f;

        foreach (Entry<BlockMaterial> entry in _entries)
        {
            currentWeight += entry.Weight;
            if (currentWeight >= rate)
            {
                return entry.Item;
            }
        }

        throw new System.Exception();
    }

    public BlockMaterial[] GetMaterials()
    {
        return _entries.Select((x) => x.Item).ToArray();
    }
}