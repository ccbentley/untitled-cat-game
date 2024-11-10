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
    
    private bool onBed = false;

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.started && scriptEnabled && onBed)
        {
            OnSleep.Invoke();
        }
    }

      private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnBed.Invoke();
            onBed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OffBed.Invoke();
            onBed = false;
        }
    }

    private void Start()
    {
        scriptEnabled = true;
    }
}
