using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.GetComponent<Player>().OnDie();
            GetComponentInParent<EnemyMovement>().enabled = false;
        }
           
    }
}
