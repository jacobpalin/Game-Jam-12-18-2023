using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveriesDone : MonoBehaviour
{
    //[SerializeField] private List<bool> deliveriesDone = new List<bool>();
    [SerializeField] private GameObject timerCanvas;

    [SerializeField] private PlaceObject[] deliveriesDone;

    private void Start()
    {
        deliveriesDone = new PlaceObject[FindObjectsOfType<PlaceObject>().Length];
        for (int i = 0; i < FindObjectsOfType<PlaceObject>().Length; i++)
        {
            deliveriesDone[i] = FindObjectsOfType<PlaceObject>()[i].GetComponent<PlaceObject>();
        }
        UpdateDeliveryBool();
    }

    public void UpdateDeliveryBool()
    {
        foreach (PlaceObject delivery in deliveriesDone)
        {
            Debug.Log(delivery.delivered);
            if(delivery.delivered == false)
            {
                timerCanvas.GetComponent<Timer>().gameEnded = false;
                break;
            }
            else
            {
                timerCanvas.GetComponent<Timer>().gameEnded = true;
            }
        }
    }
}