using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniUIManager2 : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshPro explainText;
    public TextMeshProUGUI bestScore2Text;
    public TextMeshProUGUI bestScore2;

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    int bestscore2;

    private void Awake()
    {
        bestscore2 = PlayerPrefs.GetInt("BestScore2");
    }


    // Start is called before the first frame update
    void Start()
    {
        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        explainText.gameObject.SetActive(true);

    }

    public void GameStart()
    {
        MiniManager2.Instance.GameStart();
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        explainText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        bestScore2.gameObject.SetActive(true);
        bestScore2Text.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();

        if (bestscore2 == 0)
        {
            PlayerPrefs.SetInt("BestScore2", score);
        }
        else
        {
            if (bestscore2 <= score)
            {
                PlayerPrefs.SetInt("BestScore2", score);
            }
        }

        if(bestscore2 <= score)
        {
            bestScore2Text.text = score.ToString();
        }
        else
        {
            bestScore2Text.text = bestscore2.ToString();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("BombDodge");
    }
}
