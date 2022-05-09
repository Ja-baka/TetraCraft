using UnityEngine;

public class ShapeCreator : MonoBehaviour
{
    [SerializeField] private Shape[] _shapes;

    public Shape PickRandom()
    {
        int index = Random.Range(0, _shapes.Length);
        return _shapes[index];
    }
}
