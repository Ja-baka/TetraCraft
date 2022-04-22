using System.Text;
using UnityEngine;

public class FieldDebugDrawer : MonoBehaviour
{
    [SerializeField] private Field _field;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private ActiveTetramino _tetramino;

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
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < _field.Cells.GetLength(1); y++)
        {
            for (int x = 0; x < _field.Cells.GetLength(0); x++)
            {
                sb.Append(_field.Cells[x, _field.Cells.GetLength(1) - 1 - y] == null ? "░░" : "██");
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }
}
