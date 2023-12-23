using UnityEngine;

public class TriggerDeerAndDoor : MonoBehaviour
{
    public Transform player; // Assign the player object in the Unity Editor
    public float activationDistance = 5f; // Set the distance for activation in the Unity Editor
    private Animator object1Animator;
    private bool animationsPlayed = false;

    void Start()
    {
        // Get the Animator components of both objects
        object1Animator = GameObject.FindGameObjectWithTag("DeerTag").GetComponent<Animator>();
    }

    void Update()
    {
        // Check the distance between the player and each object
        float distanceToPlayer1 = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the activation distance and the animations haven't been played yet
        if (distanceToPlayer1 < activationDistance && !animationsPlayed)
        {
            // Play the animations for both objects simultaneously
            object1Animator.SetTrigger("DeerTrigger");

            // Set a flag to indicate that animations have been played
            animationsPlayed = true;
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