using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(LevelManager.instance.canWin)
                collision.transform.GetComponent<Player>().OnReachGoal(transform);      
        }

    }
}
