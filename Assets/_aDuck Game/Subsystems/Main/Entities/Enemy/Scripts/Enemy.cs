using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    public bool alive;

    private void Start()
    {
        LevelManager.instance.enemyList.Add(this);
    }

    public virtual void OnDying() 
    {
        alive = false;
        LevelManager.instance.enemyList.Remove(this);
        LevelManager.instance.TestEndgame();
    }
}
