using System.Text;
using UnityEngine;

public class FieldDebugDrawer : MonoBehaviour
{
    [SerializeField] private Field _field;

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
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < cells.GetLength(1); y++)
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                sb.Append(cells[x, cells.GetLength(1) - 1 - y] == null ? "░░" : "██");
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }
}
