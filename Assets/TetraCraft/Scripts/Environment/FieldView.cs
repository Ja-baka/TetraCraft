using UnityEngine;

public class FieldView : MonoBehaviour
{
    [SerializeField] private Field _field;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;
    [SerializeField] private BlockMaterial _material;

    private GameObject[,] _cubes;

    private void Start()
    {
        const int ClassicWidth = 10;
        const int ClassicHeigth = 20;

        _cubes = new GameObject[ClassicWidth, ClassicHeigth];

        for (int i = 0; i < _field.Cells.GetLength(0); i++)
        {
            for (int j = 0; j < _field.Cells.GetLength(1); j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.SetActive(false);
                cube.transform.SetParent(transform, false);
                cube.transform.position = new Vector3(i, j);
                cube.GetComponent<Renderer>().material = _material.Material;
                _cubes[i, j] = cube;
            }
        }
    }

    private void OnEnable()
    {
        _spawner.TetraminoSpawned += (x) => DrawField();
        _tetramino.TetraminoMoved += (x) => DrawField();
        _tetramino.Falled += (x) => DrawField();
    }

    private void OnDisable()
    {
        _spawner.TetraminoSpawned -= (x) => DrawField();
        _tetramino.TetraminoMoved -= (x) => DrawField();
        _tetramino.Falled -= (x) => DrawField();
    }


    private void DrawField()
    {
        for (int i = 0; i < _field.Cells.GetLength(0); i++)
        {
            for (int j = 0; j < _field.Cells.GetLength(1); j++)
            {
                _cubes[i, j].SetActive(_field.Cells[i, j] != null);
            }
        }
    }
}
