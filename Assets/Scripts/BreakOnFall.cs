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
    Collider2D touchingCol;
    Damageable damageable;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    public float breakVelocity = 5f;
    public float groundDistance = 0.05f;

    [SerializeField]
    private bool _isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingCol = GetComponent<Collider2D>();
        damageable = GetComponent<Damageable>();
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

        if (IsGrounded && rb.linearVelocity.y <= -breakVelocity && damageable.IsAlive)
        {
            damageable.IsAlive = false;
        }
    }
}