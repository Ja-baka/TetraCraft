using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BlockMaterial", fileName = "BlockMaterial")]
public class BlockMaterial : ScriptableObject
{
    [SerializeField] private GameObject _model;
    //[SerializeField] private PhysicBehaviour _physic;

    public GameObject Model => _model;
}
