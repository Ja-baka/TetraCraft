using UnityEngine;

[RequireComponent(typeof(ActiveTetramino))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private ActiveTetramino _tetramino;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Tetramino.MoveLeft
            .performed += (ctx) => OnMoveLeft();
        _input.Tetramino.MoveRight
            .performed += (ctx) => OnMoveRight();

        _tetramino = GetComponent<ActiveTetramino>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnMoveLeft()
    {
        _tetramino.TryMoveLeft();
    }

    private void OnMoveRight()
    {
        _tetramino.TryMoveRight();
    }
}
