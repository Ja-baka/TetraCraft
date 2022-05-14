using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private Tetramino _tetramino;

    [Inject]
    public void Constructor(PlayerInput input, Tetramino tetramino)
    {
        _input = input;
        _tetramino = tetramino;
    }

    private void Awake()
    {
        _input.Tetramino.MoveLeft
            .performed += (ctx) => OnMoveLeft();

        _input.Tetramino.MoveRight
            .performed += (ctx) => OnMoveRight();

        _input.Tetramino.Rotate
            .performed += (ctx) => OnRotate();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnRotate()
    {
        _tetramino.TryRotate();
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
