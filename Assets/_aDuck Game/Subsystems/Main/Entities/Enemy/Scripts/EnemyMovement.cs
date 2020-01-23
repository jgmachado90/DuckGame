using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int direction;
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xOffset = transform.position.x + direction * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);


        // Cast a ray straight down.
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.9f);

        // If it hits something...

        if (hit.collider == null)
        {
           
            if (direction == 1) { direction = -1; }
            else if (direction == -1) { direction = 1; }
        

        }
    }
}
