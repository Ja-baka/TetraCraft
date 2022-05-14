using UnityEngine;
using Zenject;

public class Booster : MonoBehaviour
{
    private PlayerInput _input;
    private Timer _timer;

    [Inject]
    public void Constructor(PlayerInput input, Timer timer)
    {
        _input = input;
        _timer = timer;
    }

    private void Awake()
    {
        _input.Tetramino.Boost
            .started += (ctx) => OnBoostStarted();
        _input.Tetramino.Boost
            .canceled += (ctx) => OnBoostEnded();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnBoostStarted()
    {
        _timer.StartBoost();
    }

    private void OnBoostEnded()
    {
        _timer.EndBoost();
    }
}
