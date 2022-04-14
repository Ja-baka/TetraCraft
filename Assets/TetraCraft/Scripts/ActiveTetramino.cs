using UnityEngine;

public class ActiveTetramino : MonoBehaviour
{
    private const float Tick = 1;
    private Shape _shape;
    private BlockMaterial _material;
    private Block[] _blocks;
    private float _passedTime = 0;

    public void Init(Shape shape, BlockMaterial material)
    {
        _shape = shape;
        _material = material;
        _blocks = new Block[4]
        {
            new Block(shape.Positions[0], _material),
            new Block(shape.Positions[1], _material),
            new Block(shape.Positions[2], _material),
            new Block(shape.Positions[3], _material),
        };
    }

    public Shape Shape => _shape;
    public BlockMaterial Material => _material;
    public Block[] Blocks => _blocks;

    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime > Tick)
        {
            _passedTime = 0;
            Fall();
        }
    }

    public void Fall()
    {
        Debug.Log("Fall");
    }
}
