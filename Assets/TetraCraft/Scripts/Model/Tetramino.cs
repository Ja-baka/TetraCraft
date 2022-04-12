using UnityEngine;

public class Tetramino : MonoBehaviour
{
    private Shape _shape;

    private void Awake()
    {
        _shape = ShapeFactory.GenerateRandomShape();
    }
}
