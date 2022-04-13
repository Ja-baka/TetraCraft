using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Shapes", fileName = "Shape")]
public class Shape : ScriptableObject
{
    [SerializeField] private Vector2Int[] _blocks;
    [SerializeField] private Vector2 _pivot;

    public Vector2Int[] Blocks => _blocks;

    private void OnValidate()
    {
        if (Blocks.Length != 4)
        {
            throw new System.ArgumentException();
        }
    }
}
