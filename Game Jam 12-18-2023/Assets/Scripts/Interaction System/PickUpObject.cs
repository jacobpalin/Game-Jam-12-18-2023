using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [Header("Riddles")]
    public string riddle;
    public TextMeshProUGUI uiRiddleText;

    [Header("Start Game Text")]
    public GameObject startingText;

    [Header("Timer")]
    public Timer timer;

    Transform pickUp;
    Rigidbody rb;

    public bool objecPickedUp = false;

    private void Awake()
    {
        pickUp = gameObject.transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(objecPickedUp == true)
        {
            uiRiddleText.text = riddle;
        }
        else
        {
            uiRiddleText.text = "";
        }
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

        objecPickedUp = true;
    }

    public void DropObject()
    {
        pickUp.parent = null;
        rb.useGravity = true;
        rb.isKinematic = false;

        objecPickedUp = false;
    }
}
