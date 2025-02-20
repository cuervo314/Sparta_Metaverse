using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniManager1 : MonoBehaviour
{
    static MiniManager1 miniManager1;
    Animator animator;

    public static MiniManager1 Instance { get { return miniManager1; } }

    private int currentScore = 0;

    MiniUIManager1 miniUIManager1;

    public MiniUIManager1 MiniUIManager1 { get { return miniUIManager1; } }


    private void Awake()
    {
        Time.timeScale = 0;
        miniManager1 = this;
        miniUIManager1 = FindObjectOfType<MiniUIManager1>();
    }
    // Start is called before the first frame update
    public void GameStart()
    {
        Time.timeScale = 1;
        miniUIManager1.UpdateScore(0);
    }


    public void GameOver()
    {
        miniUIManager1.SetRestart();
        Time.timeScale = 0;
    }


    public void AddScore(int score)
    {
        currentScore += score;
        miniUIManager1.UpdateScore(currentScore);
    }
}
