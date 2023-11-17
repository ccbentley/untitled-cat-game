using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BreakOnFall : MonoBehaviour
{
    public ContactFilter2D castFilter;
    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    public float breakVelocity = 5f;
    public float groundDistance = 0.05f;

    [SerializeField]
    private bool _isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingCol = GetComponent<BoxCollider2D>();
    }

    private bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            _isGrounded = value;
        }
    }

    private void Update()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;

        if (IsGrounded && rb.velocity.y <= -breakVelocity)
        {
            animator.SetBool(AnimationStrings.isAlive, false);
        }
    }
}