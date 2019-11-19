using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            ResetStats();
            SceneManager.LoadScene(1);
        }
    }
    public void LoadLevelByIndex(int level)
    {
        ResetStats();
        SceneManager.LoadScene(level);
    }

    public void ResetStats()
    {
        Player.score = 0;
        Player.lives = 3;
        Player.missed = 0;
        Player.proType = 1;
    }
}
