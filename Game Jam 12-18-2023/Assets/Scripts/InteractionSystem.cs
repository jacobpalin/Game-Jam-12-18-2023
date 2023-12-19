using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public float pickUpDistance;
    public Transform playerCamera;
    public Transform snapLocation;
    public LayerMask objectMask;

    private void FixedUpdate()
    {
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, pickUpDistance, objectMask))
        {
            Debug.Log("Can Pick Up");

            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked Up");

                if (TryGetComponent(out PickUpObject pickUpObject))
                {
                    Debug.Log("Grabbed");

                    pickUpObject.PickUp(snapLocation);
                }
            }
        }
    }
}
