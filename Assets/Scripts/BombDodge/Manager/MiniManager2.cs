using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniManager2 : MonoBehaviour
{

    public GameObject bomb;
    static MiniManager2 miniManager2;
    Animator animator;

    public static MiniManager2 Instance { get { return miniManager2; } }

    private int currentScore = 0;

    MiniUIManager2 miniUIManager2;

    public MiniUIManager2 MiniUIManager2 { get { return miniUIManager2; } }


    private void Awake()
    {
        Time.timeScale = 0f;
        miniManager2 = this;
        miniUIManager2 = FindObjectOfType<MiniUIManager2>();
    }
    // Start is called before the first frame update
    public void GameStart()
    {
        Time.timeScale = 1;
        InvokeRepeating("MakeBomb", 0f, 0.25f);
        miniUIManager2.UpdateScore(0);
    }


    public void AddScore(int score)
    {
        currentScore += score;
        miniUIManager2.UpdateScore(currentScore);
    }
           

    public void MakeBomb()
    {
        Instantiate(bomb);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        miniUIManager2.SetRestart();
    }
}
