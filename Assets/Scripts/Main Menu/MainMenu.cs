using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;

    void Start()
    {
        MainMenuButton();
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

    public void SettingsButton()
    {
        Main.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        Main.SetActive(true);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
