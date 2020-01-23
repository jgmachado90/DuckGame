using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelManager.instance.StartCoroutine(LevelManager.instance.ResetGameCoroutine());
        }
    }
}
