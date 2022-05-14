using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FieldView : MonoBehaviour
{
    [SerializeField] private Creator _materialCreator;

    private FieldEventLocator _locator;
    private FieldCells _cells;
    private Dictionary<BlockMaterial, GameObject[,]> _cubes;

    [Inject]
    public void Constructor(FieldEventLocator locator, FieldCells cells)
    {
        _locator = locator;
        _cells = cells;
    }

    private void Start()
    {
        BlockMaterial[] materials = _materialCreator.GetMaterials();
        _cubes = new Dictionary<BlockMaterial, GameObject[,]>();

        foreach (BlockMaterial material in materials)
        {
            Iteration(material);
        }
    }

    private void Iteration(BlockMaterial material)
    {
        BlockMaterial[,] temp = _cells.CellsClone;

        GameObject[,] blocks = new GameObject[temp.GetLength(0), temp.GetLength(1)];
        _cubes.Add(material, blocks);

        for (int i = 0; i < _cubes[material].GetLength(0); i++)
        {
            for (int j = 0; j < _cubes[material].GetLength(1); j++)
            {
                GameObject cube = GameObject
                    .CreatePrimitive(PrimitiveType.Cube);
                cube.SetActive(false);
                cube.transform.SetParent(transform, false);
                cube.transform.position = new Vector3(i, j);
                cube.GetComponent<Renderer>().material
                    = material.Material;

                _cubes[material][i, j] = cube;
            }
        }
    }

    private void OnEnable()
    {
        _locator.Updated += DrawField;
    }

    private void OnDisable()
    {
        _locator.Updated -= DrawField;
    }

    private void DrawField(BlockMaterial[,] newField)
    {
        foreach (KeyValuePair<BlockMaterial, GameObject[,]> pair in _cubes)
        {
            for (int i = 0; i < pair.Value.GetLength(0); i++)
            {
                for (int j = 0; j < pair.Value.GetLength(1); j++)
                {
                    pair.Value[i, j].SetActive(newField[i, j] == pair.Key);
                }
            }
        }
    }
}
