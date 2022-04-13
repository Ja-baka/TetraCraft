using System.Collections.Generic;
using UnityEngine;

public class ShapePicker : MonoBehaviour
{
    [SerializeField] private List<Shape> _shapes;

    public Shape PickRandomMaterial()
    {
        int randomNumber = Random.Range(0, _shapes.Count);
        return _shapes[randomNumber];
    }
}
