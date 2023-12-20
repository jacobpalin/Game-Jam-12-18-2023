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
        pickUp.parent = snapLocation;

        rb.useGravity = false;
    }

    public void DropObject()
    {
        pickUp.parent = null;
        rb.useGravity = true;
    }
}
