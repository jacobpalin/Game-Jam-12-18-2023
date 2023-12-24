using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [Header("Attch Transform")]
    [SerializeField] private Transform placeTransform;

    [Header("Tag Name")]
    [SerializeField] private string tagName;
    [Space]
    [SerializeField] private InteractionSystem interactionSystem;
    public PickUpObject pickUpObject;

    [Header("Deliveries")]
    public bool delivered;

    AudioSource auidoSource;

    private void Awake()
    {
        auidoSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            //Debug.Log("Entered");

            other.transform.position = placeTransform.position;
            other.transform.rotation = placeTransform.rotation;

            other.transform.parent = placeTransform;

            interactionSystem.pickUpObject = null;
            // interactionSystem.riddles = null;

            interactionSystem.riddles.ResetRiddle();

            delivered = true;
            interactionSystem.GetComponent<DeliveriesDone>().UpdateDeliveryBool();

            auidoSource.Play();
        }
        else
        {
            //Debug.Log("Wrong Object");
        }
    }
}