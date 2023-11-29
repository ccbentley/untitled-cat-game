using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


[RequireComponent(typeof(Rigidbody2D))]
public class HitDetection : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Damageable damageable;
    AudioSource audioSource;
    GameObject player;

    [Header("Audio")]
    public AudioClip hit1;
    public float hit1Volume = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();

    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
        audioSource.PlayOneShot(hit1, hit1Volume);
    }
}
