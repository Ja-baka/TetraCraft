using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<BlockMaterial> _materials;
    [SerializeField] private List<Shape> _shapes;
    [SerializeField] private GameObject _tetramino;

    private void Start()
    {
        _tetramino.GetComponent<ActiveTetramino>()
            .Init(_shapes[0], _materials[0]);

        Instantiate(_tetramino, transform);
    }
}
