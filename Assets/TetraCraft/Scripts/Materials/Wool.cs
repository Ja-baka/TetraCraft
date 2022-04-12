using UnityEngine;

[CreateAssetMenu(fileName = "Wool", menuName = "ScriptableObjects/Material/Wool", order = 1)]
public class Wool : Material
{
    [SerializeField] private GameObject _model;

    public override GameObject Model => _model;
}
