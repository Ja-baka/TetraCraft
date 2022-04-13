using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Shapes", fileName = "Shape")]
public class Shape : ScriptableObject
{
    [SerializeField] private Block[] _blocks;
    [SerializeField] private Vector2 _pivot;

    public Block[] Blocks => _blocks;

    private void OnValidate()
    {
        if (Blocks.Length != 4)
        {
            throw new System.ArgumentException();
        }
    }
}
