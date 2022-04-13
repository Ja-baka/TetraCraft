using UnityEngine;

public abstract class Shape : ScriptableObject
{
    public abstract Block[] Blocks { get; }

    private void OnValidate()
    {
        if (Blocks.Length != 4)
        {
            throw new System.ArgumentException();
        }
    }
}
