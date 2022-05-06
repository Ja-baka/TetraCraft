using UnityEngine;

[CreateAssetMenu(menuName = "SO/BlockMaterial/New material", fileName = "New Block Material")]
public class BlockMaterial : ScriptableObject
{
    [SerializeField] private Material _material;

    public Material Material => _material;

    [SerializeField] private ScriptableObject _weight;

    public IWeight Weight => (IWeight)_weight;

    private void OnValidate()
    {
        if (_weight is IWeight)
        {
            return;
        }

        Debug.LogError($"{_weight.name} needs to implement "
            + $"{nameof(IWeight)}");
        _weight = null;
    }
}
