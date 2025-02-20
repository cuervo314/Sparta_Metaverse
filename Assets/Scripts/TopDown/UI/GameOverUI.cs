using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restratButton;
    [SerializeField] private Button exitButton;
    public TextMeshProUGUI bestScore4;
    public TextMeshProUGUI bestScore4Text;

    public override void Init(MiniUIManager4 miniUIManager4)
    {
        base.Init(miniUIManager4);

        restratButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void Start()
    {
        Time.timeScale = 0f;
        restratButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        bestScore4.gameObject.SetActive(true);
        bestScore4Text.gameObject.SetActive(true);
    }

    public void OnClickRestartButton()
    {
        restratButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);
        bestScore4.gameObject.SetActive(false);
        bestScore4Text.gameObject.SetActive(false);
        SceneManager.LoadScene("TopDown");
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
