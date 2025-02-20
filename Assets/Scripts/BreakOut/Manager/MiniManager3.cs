using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniManager3 : MonoBehaviour
{
    static MiniManager3 miniManager3;
    Animator animator;

    public static MiniManager3 Instance { get { return miniManager3; } }

    private int currentScore = 0;

    MiniUIManager3 miniUIManager3;

    public MiniUIManager3 MiniUIManager3 { get { return miniUIManager3; } }

    public GameObject fireBall;

    MiniPlayer3 miniPlayer3;

    EnemyController enemyController;


    private void Awake()
    {
        Time.timeScale = 0f;
        miniManager3 = this;
        miniPlayer3 = FindObjectOfType<MiniPlayer3>();
        miniUIManager3 = FindObjectOfType<MiniUIManager3>();
        enemyController = FindObjectOfType<EnemyController>();
    }

    // Start is called before the first frame update
    public void GameStart()
    {
        Time.timeScale = 1;
        enemyController.SpawnEnemy();
        InvokeRepeating("ShootFireBall", 0, 2.5f);
        miniUIManager3.UpdateScore(0);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        miniUIManager3.UpdateScore(currentScore);
    }          

    public void ShootFireBall()
    {
        Instantiate(fireBall, miniPlayer3.transform);
    }
}
