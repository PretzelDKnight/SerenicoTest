using UnityEngine;

public class TouchJoystickInput : MonoBehaviour, IInput
{
    public event EventCall onBegin;
    public event DirectionEventCall onMoving;
    public event EventCall onStationary;
    public event EventCall onEnd;

    Vector2 downPos;
    Vector2 pos;
    Vector2 delta;

    [SerializeField] float minMagnitude;
    [SerializeField] float sensitivity;
    [SerializeField] KeyCode inputKey = KeyCode.Mouse0;

    void Update()
    {
        MouseInput(inputKey);
    }

    void MouseInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            downPos = Input.mousePosition;
            pos = Input.mousePosition;
            delta = Vector2.zero;

            if (onBegin != null)
            onBegin.Invoke();

            return;
        }

        if (Input.GetKeyUp(key))
        {
            pos = Input.mousePosition;
            downPos = Input.mousePosition;
            delta = Vector2.zero;

            if (onEnd != null)
                onEnd.Invoke();

            return;
        }

        if (Input.GetKey(key))
        {
            pos = Input.mousePosition;
            delta = (pos - downPos) * sensitivity;

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