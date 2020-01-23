using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJellyFish : Enemy
{
    [SerializeField] float playerImpulse;
    [SerializeField] float trailTime;
   
    private JellyFishParticles jellyFishParticles;

    private void Start()
    {
        jellyFishParticles = GetComponentInChildren<JellyFishParticles>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up *  Mathf.Sqrt(-collision.GetComponent<Rigidbody2D>().velocity.y) * playerImpulse, ForceMode2D.Impulse);
            Camera.main.GetComponent<ShakeBehaviour>().TriggerShake(-collision.GetComponent<Rigidbody2D>().velocity.y);
            StartCoroutine(PlayTrailEffectsWhileBouncing(collision));
            OnDying();
        }
    }

    IEnumerator PlayTrailEffectsWhileBouncing(Collider2D collision)
    {
        collision.transform.GetComponentInChildren<PlayerParticles>().bounceTrail.Play();
        GetComponentInChildren<JellyFishParticles>().bounceFeedback.Play();
        yield return new WaitForSeconds(trailTime);
        collision.transform.GetComponentInChildren<PlayerParticles>().bounceTrail.Pause();

    }

    public override void OnDying()
    {
        base.OnDying();
        jellyFishParticles.deathParticle.Play();
        GetComponentInParent<Rigidbody2D>().isKinematic = false;
        Destroy(this.gameObject, 0.5f);

    }
}
