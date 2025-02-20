using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniUIManager1 : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshPro explainText;
    public TextMeshProUGUI bestScore1Text;
    public TextMeshProUGUI bestScore1;

    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    int bestscore1;

    private void Awake()
    {
        bestscore1 = PlayerPrefs.GetInt("BestScore1");
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
        MiniManager1.Instance.GameStart();
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        explainText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        bestScore1.gameObject.SetActive(true);
        bestScore1Text.gameObject.SetActive(true);
    }
    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();

        if (bestscore1 == 0)
        {
            PlayerPrefs.SetInt("BestScore1", score);
        }
        else
        {
            if (bestscore1 <= score)
            {
                PlayerPrefs.SetInt("BestScore1", score);
            }
        }

        if(bestscore1 <= score)
        {
            bestScore1Text.text = score.ToString();
        }
        else
        {
            bestScore1Text.text = bestscore1.ToString();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyPlane");
    }
}
