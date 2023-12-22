using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("Distance to Pick Up")]
    [SerializeField] private float pickUpDistance;

    [Header("Camera and Snap Transform")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform snapLocation;

    [Header("Interaction Layer")]
    [SerializeField] private LayerMask objectMask;
    public LayerMask placeMask;

    public float placeDistance;

    private PickUpObject pickUpObject;
    RaycastHit hit;

    private void Update()
    {
        if (pickUpObject == null)
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickUpDistance, objectMask))
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
