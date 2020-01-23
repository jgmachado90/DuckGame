using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool canWin;

    public List<Enemy> enemyList = new List<Enemy>();

    private void Awake()
    {
        instance = this;
        canWin = false;
        
    }

    public void TestEndgame()
    {
        if (enemyList.Count == 0)
            canWin = true;
    }

    public IEnumerator ResetGameCoroutine()
    {

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    internal void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
