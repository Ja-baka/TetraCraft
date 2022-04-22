using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Tetramino.MoveLeft
            .performed += (ctx) => OnMoveLeft();
        _input.Tetramino.MoveRight
            .performed += (ctx) => OnMoveRight();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnMoveRight()
    {
        Debug.Log("MoveRight");
    }

    private void OnMoveLeft()
    {
        Debug.Log("MoveLeft");
    }
}
