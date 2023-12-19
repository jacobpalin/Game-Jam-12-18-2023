using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform pickUp;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform snapLocation)
    {
        pickUp.position = snapLocation.position;
        rb.useGravity = false;
    }

    public void DropObject()
    {
        rb.useGravity = true;
    }
}
