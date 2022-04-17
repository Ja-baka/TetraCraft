using System;
using UnityEngine;

public class ActiveTetramino : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Field _field;

    private Block[] _blocks;
    private GameObject[] _cubes;

    public void Init(Shape shape, BlockMaterial material)
    {
        _blocks = new Block[4];
        _cubes = new GameObject[4];
        for (int i = 0; i < _blocks.Length; i++)
        {
            Vector2Int position = shape.Positions[i];
            _blocks[i] = new Block(position, material);

            // View
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(transform, false);
            cube.transform.position = new Vector3(position.x, position.y);
            cube.GetComponent<Renderer>().material = material.Material;
            _cubes[i] = cube;
            // View
        }
    }

    public event Action<GameObject[]> Falled;
    public event Action<Vector2Int> TetraminoMoved;

    public Block[] Blocks => _blocks;

    private void OnEnable()
    {
        _timer.Tick += TryFall;
    }

    private void OnDisable()
    {
        _timer.Tick -= TryFall;
    }

    private void TryFall()
    {
        if (_field.IsCanFall(_blocks) == false)
        {
            ReachBottom();
            return;
        }

        TetraminoMoved?.Invoke(Vector2Int.down); 
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].Fall();

            // View
            _cubes[i].transform.position += Vector3.down;
            // View
        }
    }

    public void ReachBottom()
    {   
        Falled?.Invoke(_cubes);
    }
}
