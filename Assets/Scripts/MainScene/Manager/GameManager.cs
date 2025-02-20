using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player {  get; set; }

    private void Awake()
    {
        Time.timeScale = 1f;
        //PlayerPrefs.DeleteAll();
        Instance = this;

        player = FindObjectOfType<PlayerController>();
        player.Init(this);
    }
}
