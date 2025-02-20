using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    public TextMeshProUGUI waveText;
    [SerializeField] private Slider hpSlider;

    MiniUIManager4 miniUIManager4;

    private void Awake()
    {
        miniUIManager4 = FindAnyObjectByType<MiniUIManager4>();
    }

    private void Start()
    {
        UpdateHPSlider(1);
    }

    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }    

    public void UpdateWaveText(int wave)
    {
        waveText.text = wave.ToString();
        miniUIManager4.UpdateScore(wave);
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }


}
