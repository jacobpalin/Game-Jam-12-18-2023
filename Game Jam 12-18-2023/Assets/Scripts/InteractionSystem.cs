using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public float pickUpDistance;
    public Transform playerCamera;
    public Transform snapLocation;
    public LayerMask objectMask;

    private PickUpObject pickUpObject;

    private void Update()
    {
        if (pickUpObject == null)
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, pickUpDistance, objectMask))
            {
                Debug.Log(hit.transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.TryGetComponent(out pickUpObject))
                    {
                        pickUpObject.PickUp(snapLocation);
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            pickUpObject.DropObject();

            pickUpObject = null;
        }
    }
}
