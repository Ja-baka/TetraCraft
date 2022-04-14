using UnityEngine;

public class BlockMaterial : ScriptableObject
{
    [SerializeField] private Material _material;

    public Material Material => _material;

    private void SetCurrentMaterialToCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material = _material;
    }
}
