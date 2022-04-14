using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ActiveTetramino activeTetramino;

    private void Awake()
    {
        BlockMaterial material
            = new MaterialCreator().PickRandom();
        Shape shape
            = new ShapeCreator().PickRandom();

        throw new System.NotImplementedException();
    }

    public void Spawn()
    {
        throw new System.NotImplementedException();
    }
}
