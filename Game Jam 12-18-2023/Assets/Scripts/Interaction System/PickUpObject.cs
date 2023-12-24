using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    Transform pickUp;
    Rigidbody rb;

    public GameObject startingText;

    public Timer timer;

    private void Awake()
    {
        pickUp = gameObject.transform;
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform snapLocation)
    {
        pickUp.position = snapLocation.position;
        pickUp.rotation = snapLocation.rotation;
        pickUp.parent = snapLocation;

        timer.isTimerOn = true;
        startingText.SetActive(false);

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
