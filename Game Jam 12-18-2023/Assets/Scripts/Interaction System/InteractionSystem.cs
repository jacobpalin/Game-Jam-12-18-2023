using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Distance to Pick Up")]
    [SerializeField] private float pickUpDistance;

    [Header("Camera and Snap Transform")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform snapLocation;

    [Header("Interaction Layer")]
    [SerializeField] private LayerMask objectMask;

    [Header("DO NOT DRAG ANYTHING INTO THIS")]
    public PickUpObject pickUpObject;

    [SerializeField] private Image corsshair;

    RaycastHit hit;

    private void Update()
    {
        if (pickUpObject == null)
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickUpDistance, objectMask))
            {
                //Debug.Log(hit.transform);
                corsshair.color = Color.red;

                if (Input.GetMouseButton(0))
                {
                    if (hit.transform.TryGetComponent(out pickUpObject))
                    {
                        pickUpObject.PickUp(snapLocation);
                    }

                    corsshair.color = Color.green;
                }
            }
            else
            {
                corsshair.color = Color.green;
            }
        }

        if(Input.GetMouseButton(1))
        {
            pickUpObject.DropObject();

            pickUpObject = null;
        }
    }
}
