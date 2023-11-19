using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{   
    AudioSource audioSource;
    public PlayerController playerController;
    public TouchingDirections touchingDirections;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerController.IsMoving && touchingDirections.IsGrounded)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
