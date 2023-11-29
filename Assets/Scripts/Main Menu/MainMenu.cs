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

    void Start()
    {
        MainMenuButton();
        DisplayLastTime(Variables.lastTime);
    }

    void DisplayLastTime(float timeToDisplay)
    {
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    lastTimeText.text = string.Format("Previous Time: {0:00}:{1:00}", minutes, seconds);
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
