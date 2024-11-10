using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    private void Awake()
    {
        LeanTween.reset();
    }

    private void Start()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        // LeanTween.alpha (fader, 1, 0);
        // LeanTween.alpha (fader, 0, 0.5f).setOnComplete (() => {
        //     fader.gameObject.SetActive (false);
        // });

        // SCALE
        LeanTween.scale(fader, new Vector2(1, 1), 0);
        LeanTween.scale(fader, Vector2.zero, 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

     public void OpenMenuScene()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        // LeanTween.alpha (fader, 0, 0);
        // LeanTween.alpha (fader, 1, 0.5f).setOnComplete (() => {
        //     SceneManager.LoadScene (0);
        // });

        // SCALE
        LeanTween.scale(fader, Vector2.zero, 0f);
        LeanTween.scale(fader, new Vector2(1, 1), 5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
            Invoke("LoadMenu", 0.2f);
        });
    }

    public void OpenGameScene()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        // LeanTween.alpha (fader, 0, 0);
        // LeanTween.alpha (fader, 1, 0.5f).setOnComplete (() => {
        //     // Example for little pause before laoding the next scene
        //     Invoke ("LoadGame", 0.5f);
        // });

        // SCALE
        LeanTween.scale(fader, Vector2.zero, 0f);
        LeanTween.scale(fader, new Vector2(1, 1), 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
            // Example for little pause before laoding the next scene
            Invoke("LoadGame", 0.5f);
        });
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OpenMenuScene();
        }
    }

    public void OnRetry(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            LoadGame();
        }
    }
}
