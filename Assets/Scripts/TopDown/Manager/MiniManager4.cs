using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniManager4 : MonoBehaviour
{
    public static MiniManager4 Instance;

    public PlayerController4 player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    private EnemyManager enemyManager;

    private MiniUIManager4 miniUIManager4;

    private void Awake()
    {
        Instance = this;

        player = FindObjectOfType<PlayerController4>();
        player.Init(this);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);

        miniUIManager4 = FindObjectOfType<MiniUIManager4>();

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(miniUIManager4.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(miniUIManager4.ChangePlayerHP);
    }

    public void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        miniUIManager4.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);
        miniUIManager4.ChangeWave(currentWaveIndex);
    }

    public void EndofWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        enemyManager.StopWave();
        miniUIManager4.SetGameOver();
    }
}
