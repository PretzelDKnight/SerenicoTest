using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] float force = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Remove")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0,0,1) * force);
        }
    }
}
