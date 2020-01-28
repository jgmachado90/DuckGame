using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator playerAnimator;
    PlayerParticles playerParticles;

    public bool alive;
    public bool canMove;
    private void Awake()
    {
        alive = true;
        canMove = true;
    }

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerParticles = GetComponentInChildren<PlayerParticles>();
    }

    private void Update()
    {
        
    }

    internal void OnReachGoal(Transform goal)
    {
        StartCoroutine(OnReachGoalCoroutine(goal));
        
    }

    IEnumerator OnReachGoalCoroutine(Transform goal)
    {
        canMove = false;
        Transform start = transform;
        Transform end = goal;
        float speed = 0.1f;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(start.position, end.position);
        while (Vector3.Distance(transform.position, goal.position) > 0.1f)
        {
                 // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(start.position, end.position, fractionOfJourney);
            yield return null;
        }
        StartCoroutine(LookingToScreen());
    }

    IEnumerator LookingToScreen()
    {
        Transform from = transform;
        float speed = 0.1f;
        if (transform.localRotation.x > 0.7f)
        {
            while (transform.localRotation.y > 0.70f)
            {
                transform.RotateAround(transform.position, transform.up, -30 * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (transform.localRotation.y < 0.70f)
            {
                transform.RotateAround(transform.position, transform.up, 30 * Time.deltaTime);
                yield return null;
            }
        }
        LevelManager.instance.CompleteLevel();
    }

    public void OnDie()
    {
        alive = false;    
        playerParticles.deathByJellyParticles.Play();
        playerAnimator.SetBool("Jump", true);
        LevelManager.instance.StartCoroutine(LevelManager.instance.ResetGameCoroutine());
        DeathCounter.instance.Add();
    }

   
}
