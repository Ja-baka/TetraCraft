using System.Linq;
using UnityEngine;

public class MaterialCreator : MonoBehaviour
{
    [System.Serializable]
    private class Entry
    {
        public BlockMaterial Material;
        [Range(0, 1)] public float Weight;
    }

    [SerializeField] private Entry[] _entries;

    public BlockMaterial[] GetCollection()
    {
        return _entries.Select((x) => x.Material).ToArray();
    }

    public BlockMaterial PickRandom()
    {
        float totalWeight = _entries.Sum((x) => x.Weight);
        float random = Random.value;
        float rate = random * totalWeight;
        float currentWeight = 0f;

        foreach (Entry entry in _entries)
        {
            currentWeight += entry.Weight;
            if (currentWeight >= rate)
            {
                return entry.Material;
            }
        }

        throw new System.Exception();
    }
}