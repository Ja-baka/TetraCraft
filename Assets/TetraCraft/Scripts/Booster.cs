using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Booster : MonoBehaviour
{
    private PlayerInput _input;
    private Timer _timer;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Tetramino.Boost
            .started += (ctx) => OnBoostStarted();
        _input.Tetramino.Boost
            .canceled += (ctx) => OnBoostEnded();

        _timer= GetComponent<Timer>();
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
