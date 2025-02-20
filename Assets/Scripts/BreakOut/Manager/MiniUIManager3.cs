using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniUIManager3 : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshPro explainText;
    public TextMeshProUGUI bestScore3Text;
    public TextMeshProUGUI bestScore3;

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    int bestscore3;

    private void Awake()
    {
        bestscore3 = PlayerPrefs.GetInt("BestScore3");
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
        MiniManager3.Instance.GameStart();
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        explainText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        bestScore3.gameObject.SetActive(true);
        bestScore3Text.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();

        if (bestscore3 == 0)
        {
            PlayerPrefs.SetInt("BestScore3", score);
        }
        else
        {
            if (bestscore3 <= score)
            {
                PlayerPrefs.SetInt("BestScore3", score);
            }
        }

        if(bestscore3 <= score)
        {
            bestScore3Text.text = score.ToString();
        }
        else
        {
            bestScore3Text.text = bestscore3.ToString();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("BreakOut");
    }
}
