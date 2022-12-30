using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(IInput))]
public abstract class Controller : MonoBehaviour

{
    protected IInput input;

    protected virtual void Awake()
    {
        input = GetComponent<IInput>();
    }

    protected virtual void OnEnable()
    {
        SubscribeToInput(input);
    }

    protected virtual void OnDisable()
    {
        SubscribeToInput(input);
    }

    protected void SubscribeToInput(IInput inter)
    {
        inter.onBegin += OnInputBegin;
        inter.onMoving += Move;
        inter.onEnd += OnInputEnd;
    }

    protected void UnsubscribeFromInput(IInput inter)
    {
        inter.onBegin -= OnInputBegin;
        inter.onMoving -= Move;
        inter.onEnd -= OnInputEnd;
    }

    protected abstract void OnInputBegin();

    protected abstract void Move(Vector2 direction);

    protected abstract void Stationary();

    protected abstract void OnInputEnd();
}