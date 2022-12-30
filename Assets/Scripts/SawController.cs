using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SawController : Controller
{
    [SerializeField] float speed;
    [SerializeField] Transform onReleaseSnapTo;

    protected override void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * Time.deltaTime;
    }

    protected override void OnInputBegin()
    {
        if (onReleaseSnapTo != null)
            transform.position = onReleaseSnapTo.position;
    }

    protected override void OnInputEnd()
    {
        if (onReleaseSnapTo != null)
            transform.position = onReleaseSnapTo.position;
    }

    protected override void Stationary()
    {
        if (onReleaseSnapTo != null)
            transform.position = onReleaseSnapTo.position;
    }
}