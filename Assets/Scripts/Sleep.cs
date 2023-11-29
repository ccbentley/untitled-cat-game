using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Sleep : MonoBehaviour
{
    public UnityEvent OnSleep;
    public UnityEvent OnBed;
    public UnityEvent OffBed;

    private bool scriptEnabled = false; 

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.started && scriptEnabled)
        {
            OnSleep.Invoke();
        }
    }

      private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnBed.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OffBed.Invoke();
        }
    }

    private void Start()
    {
        scriptEnabled = true;
    }
}
