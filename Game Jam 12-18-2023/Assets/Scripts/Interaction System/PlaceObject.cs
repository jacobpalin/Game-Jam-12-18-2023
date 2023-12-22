using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [Header("Attch Transform")]
    [SerializeField] private Transform placeTransform;

    [Header("Tag Name")]
    [SerializeField] private string tagName;
    [Space]
    [SerializeField] private InteractionSystem interactionSystem;

    [Header("Deliveries")]
    public bool delivered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            //Debug.Log("Entered");

            other.transform.position = placeTransform.position;
            other.transform.parent = null;

            interactionSystem.pickUpObject = null;

            delivered = true;
            interactionSystem.GetComponent<DeliveriesDone>().UpdateDeliveryBool();
        }
        else
        {
            //Debug.Log("Wrong Object");
        }
    }
}