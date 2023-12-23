using UnityEngine;

public class TriggerDeerAndDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Animator deerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Open");
            deerAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Close");
            deerAnimator.SetTrigger("Close");
        }
    }
}
























/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeerAndDoor : MonoBehaviour

{
    public Transform player;  // Reference to the player GameObject
    public float triggerDistance = 5f;  // Set the distance at which the animation will trigger

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < triggerDistance)
        {
            // Trigger animation
            animator.SetTrigger("DeerTrigger");
           // animator.SetTrigger("YourAnimationTrigger2");
        }
    }
}
*/