using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRelativeInput : MonoBehaviour, IInput
{
    public event EventCall onBegin;
    public event DirectionEventCall onMoving;
    public event EventCall onStationary;
    public event EventCall onEnd;

    Vector2 pos;
    Vector2 delta;

    [SerializeField] float minMagnitude;
    [SerializeField] float sensitivity;
    [SerializeField] KeyCode inputKey = KeyCode.Mouse0;

    void Update()
    {
        MouseInput(inputKey);
    }

    private void OnDisable()
    {
        onBegin = null;
        onMoving = null;
        onStationary = null;
        onEnd = null;
    }

    void MouseInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = Vector2.zero;

            if (onBegin != null)
                onBegin.Invoke();

            return;
        }

        if (Input.GetKeyUp(key))
        {
            pos = Vector2.zero;
            delta = Vector2.zero;

            if (onEnd != null)
                onEnd.Invoke();

            return;
        }

        if (Input.GetKey(key))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = (pos - (Vector2)transform.position) * sensitivity;

            if (delta.sqrMagnitude > minMagnitude * minMagnitude)
            {
                if (onMoving != null)
                    onMoving.Invoke(delta.normalized);
            }
            else
            {
                if (onStationary != null)
                    onStationary.Invoke();
            }

            return;
        }
    }
}
