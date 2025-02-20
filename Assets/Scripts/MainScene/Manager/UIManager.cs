using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScore1Text;
    public TextMeshProUGUI bestScore2Text;
    public TextMeshProUGUI bestScore3Text;
    public TextMeshProUGUI bestScore4Text;

    public Button startButton;
    public Button exitButton;
    public TextMeshPro explainText;

    private void Update()
    {
        bestScore1Text.text = PlayerPrefs.GetInt("BestScore1").ToString();
        bestScore2Text.text = PlayerPrefs.GetInt("BestScore2").ToString();
        bestScore3Text.text = PlayerPrefs.GetInt("BestScore3").ToString();
        bestScore4Text.text = PlayerPrefs.GetInt("BestScore4").ToString();
    }
}
