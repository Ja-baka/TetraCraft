using System.Collections.Generic;
using UnityEngine;

public class FieldView : MonoBehaviour
{
    [SerializeField] private Creator<BlockMaterial> _materialCreator;
    [SerializeField] private Field _field;

    private Dictionary<BlockMaterial, GameObject[,]> _cubes;

    private void Start()
    {
        BlockMaterial[] materials = _materialCreator.GetCollection();
        _cubes = new Dictionary<BlockMaterial, GameObject[,]>();

        foreach (BlockMaterial material in materials)
        {
            Iteration(material);
        }
    }

    private void Iteration(BlockMaterial material)
    {
        // https://tetris.fandom.com/wiki/Tetris_Guideline
        const int Width = 10;
        const int Heigth = 20;

        GameObject[,] blocks = new GameObject[Width, Heigth];
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
        _field.Updated += DrawField;
    }

    private void OnDisable()
    {
        _field.Updated -= DrawField;
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
