using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnToMenu : MonoBehaviour
{
    public UnityEvent returnToMenu;

    void Start()
    {
        returnToMenu.Invoke();
    }
}
