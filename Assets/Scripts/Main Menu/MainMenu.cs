using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject CreditsMenu;

    public TMP_Text lastTimeText;
    public TMP_Text bestTimeText;

    void Start()
    {
        MainMenuButton();
        DisplayLastTime(Variables.lastTime, Variables.bestTime);
    }

    void DisplayLastTime(float lastTime, float bestTime)
    {
        if (lastTime >= 0)
        {
            float minutes = Mathf.FloorToInt(lastTime / 60);
            float seconds = Mathf.FloorToInt(lastTime % 60);
            float milliseconds = (lastTime % 1) * 1000;
            lastTimeText.text = string.Format("Last Time: {0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
        else
        {
            lastTimeText.text = "Last Time: --";
        }
        if (bestTime >= 0)
        {
            float minutes = Mathf.FloorToInt(bestTime / 60);
            float seconds = Mathf.FloorToInt(bestTime % 60);
            float milliseconds = (bestTime % 1) * 1000;
            bestTimeText.text = string.Format("Best Time: {0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void CreditsButton()
    {
        Main.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        Main.SetActive(true);
        CreditsMenu.SetActive(false);
    }
}
