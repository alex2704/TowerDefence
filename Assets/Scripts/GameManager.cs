using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool GameIsWin;

    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public static bool IsContinue;

    void Start()
    {
        GameIsOver = false;
        GameIsWin = false;
        IsContinue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (!IsContinue && !GameIsWin && PlayerStats.Waves < PlayerStats.Rounds)
        {
            WinGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
    
    void WinGame()
    {
        GameIsWin = true;
        gameWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        IsContinue = true;
        gameWinUI.SetActive(false);
    }
}
