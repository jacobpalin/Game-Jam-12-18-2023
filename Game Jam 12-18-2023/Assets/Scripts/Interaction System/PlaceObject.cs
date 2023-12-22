using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public Transform placeTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            Debug.Log("Entered");

            other.transform.position = placeTransform.position;
            other.transform.parent = null;
        }
    }
}
