using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = (PlayerStats.Rounds - 1).ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
