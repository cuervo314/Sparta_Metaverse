using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;


public enum UIState
{
    Home,
    Game,
    GameOver
}
public class MiniUIManager4 : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;

    public TextMeshProUGUI bestScore4Text;

    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        gameUI.UpdateWaveText(waveIndex);
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        gameUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }

    public void UpdateScore(int score)
    {
        int bestscore4 = PlayerPrefs.GetInt("BestScore4");

        if (bestscore4 <= score)
        {
            PlayerPrefs.SetInt("BestScore4", score);
        }

        bestScore4Text.text = PlayerPrefs.GetInt("BestScore4").ToString();
    }
}
