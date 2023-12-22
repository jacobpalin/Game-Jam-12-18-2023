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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            Debug.Log("Entered");

            other.transform.position = placeTransform.position;
            other.transform.parent = null;

            interactionSystem.pickUpObject = null;
        }
        else
        {
            Debug.Log("Wrong Object");
        }
    }
}
