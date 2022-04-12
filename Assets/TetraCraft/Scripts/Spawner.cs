using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private List<Shape> _shapes;
    [SerializeField] private Tetramino _tetramino;

    private void Start()
    {
        _tetramino.Initialize(_shapes[0], _materials[0]);

        Instantiate(_tetramino, transform);
    }
}
