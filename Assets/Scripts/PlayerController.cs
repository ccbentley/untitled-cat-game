using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))] 

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float airWalkSpeed = 4f;
    public float jumpImpulse = 10f;
    public float coyoteTimeDuration = 0.2f;

    Vector2 moveInput;
    TouchingDirections touchingDirections;
    Damageable damageable;
    AudioSource audioSource;

    [Header("Audio")]
    public AudioClip land1;
    public AudioClip woosh1;
    public float land1Volume = 1;
    public float woosh1Volume = 1;


    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall || IsMoving && touchingDirections.IsOnPushableObject)
                {
                    if (touchingDirections.IsGrounded)
                    {
                        if (IsRunning)
                        {
                            return runSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }
                    else
                    {
                        // Air Move
                        return airWalkSpeed;
                    }
                }
                else
                {
                    // Idle speed is 0
                    return 0;
                }
            }
            else
            {
                //  Movement Locked
                return 0;
            }
        }
    }


    [Header("Other")]
    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get
        {
            return _isMoving;
        } private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
     }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight { get { return _isFacingRight; } private set {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            
            _isFacingRight = value;
        } }
    
    public bool CanMove { get
        {
            return animator.GetBool(AnimationStrings.canMove);
        } }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField]
    private bool isCoyoteTimeActive = false;
    private float coyoteTimeTimer = 0f;

    [SerializeField]
    private float fallSoundHight = 3f;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);

        if (touchingDirections.IsGrounded)
        {
            isCoyoteTimeActive = true;
            coyoteTimeTimer = coyoteTimeDuration;
        }
        else if (isCoyoteTimeActive)
        {
            coyoteTimeTimer -= Time.fixedDeltaTime;
            if (coyoteTimeTimer <= 0)
            {
                isCoyoteTimeActive = false;
            }
        }
        if (touchingDirections.IsGrounded && rb.velocity.y <= -fallSoundHight)
        {
            audioSource.PlayOneShot(land1, land1Volume);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirecton(moveInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetFacingDirecton(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        } 
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        } else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context )
    {
        if (context.started && touchingDirections.IsGrounded && CanMove || isCoyoteTimeActive && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);

            // Reset coyote time
            isCoyoteTimeActive = false;
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        } 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
            audioSource.PlayOneShot(woosh1, woosh1Volume);
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}