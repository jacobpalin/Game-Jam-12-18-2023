using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [Header("Start Game Text")]
    public GameObject startingText;

    [Header("Timer")]
    public Timer timer;

    Transform pickUp;
    Rigidbody rb;


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
