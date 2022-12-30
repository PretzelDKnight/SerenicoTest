using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void EventCall();
public delegate void DirectionEventCall(Vector2 direction);

public interface IInput
{
    event EventCall onBegin;
    event DirectionEventCall onMoving;
    event EventCall onStationary;
    event EventCall onEnd;
}
