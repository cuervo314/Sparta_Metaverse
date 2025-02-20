using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshPro explainText;

    public void Start()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        explainText.gameObject.SetActive(true);
    }
    public override void Init(MiniUIManager4 miniUIManager4)
    {
        base.Init(miniUIManager4);

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        Time.timeScale = 1f;
        MiniManager4.Instance.StartGame();
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}
