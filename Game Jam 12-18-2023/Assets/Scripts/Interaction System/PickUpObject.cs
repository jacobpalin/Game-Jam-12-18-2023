using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Transform pickUp;

    Rigidbody rb;

    private void Awake()
    {
        pickUp = this.gameObject.transform;
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform snapLocation)
    {
        pickUp.position = snapLocation.position;
        pickUp.parent = snapLocation;

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void DropObject()
    {
        pickUp.parent = null;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
