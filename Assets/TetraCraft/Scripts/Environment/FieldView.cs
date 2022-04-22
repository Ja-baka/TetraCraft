using UnityEngine;

public class FieldView : MonoBehaviour
{
    [SerializeField] private BlockMaterial _material;
    [SerializeField] private Field _field;

    private GameObject[,] _cubes;

    private void Start()
    {
        const int ClassicWidth = 10;
        const int ClassicHeigth = 20;

        _cubes = new GameObject[ClassicWidth, ClassicHeigth];

        for (int i = 0; i < _cubes.GetLength(0); i++)
        {
            for (int j = 0; j < _cubes.GetLength(1); j++)
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
        _field.Updated += DrawField;
    }

    private void OnDisable()
    {
        _field.Updated -= DrawField;
    }


    private void DrawField(BlockMaterial[,] cells)
    {
        for (int i = 0; i < _cubes.GetLength(0); i++)
        {
            for (int j = 0; j < _cubes.GetLength(1); j++)
            {
                _cubes[i, j].SetActive(cells[i, j] != null);
            }
        }
    }
}
