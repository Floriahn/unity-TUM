using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void LoadLevelByIndex(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResetStats()
    {
        Player.score = 0;
        Player.lives = 3;
        Player.missed = 0;
    }
}
