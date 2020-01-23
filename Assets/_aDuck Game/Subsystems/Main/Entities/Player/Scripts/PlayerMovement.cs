using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator playerAnimator;
    public Player player;
    [SerializeField] bool grounded;
    [SerializeField] float moveSpeed;
    [SerializeField] bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (player.alive && player.canMove)
        {
            MovementAnimation();
            if (Input.GetAxis("Horizontal") != 0)
            {
                MovePlayer();
                RotatePlayerToFacingSide();
            }
        }

    }

    private void GroundCheck()
    {
        // Cast a ray straight down.
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.9f);

    
        if (hit.collider == null)
        {
            grounded = false;
        }
        else if (hit.collider.tag == "Platform")
        {
            grounded = true;
        }
    }

    private void RotatePlayerToFacingSide()
    {
        if (Input.GetAxis("Horizontal") > 0 && facingLeft)
        {
            RotatePlayer();
            facingLeft = false;
        }
        if (Input.GetAxis("Horizontal") < 0 && !facingLeft)
        {
            RotatePlayer();
            facingLeft = true;
        }
    }

    private void RotatePlayer()
    {
        transform.Rotate(transform.up, 180f);
    }

    private void MovePlayer()
    {
        float xOffset = transform.position.x + Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);     
    }

    private void MovementAnimation()
    {
        //1 = right
        playerAnimator.SetBool("Walk", Input.GetAxis("Horizontal") != 0);
        playerAnimator.SetBool("Fall", !grounded);

    }

    public void OnDie()
    {
        GetComponent<Player>().alive = false;
        GetComponentInChildren<PlayerParticles>().deathByJellyParticles.Play();

        playerAnimator.SetBool("Jump", true);
        
    }


}
