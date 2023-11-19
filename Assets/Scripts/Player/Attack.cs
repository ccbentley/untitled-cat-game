using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    [Header("Audio")]
    AudioSource audioSource;
    public AudioClip hit1;
    public float hit1Volume = 1;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // See if it can be hit
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable != null)
        {
            // If parent is facing the left by localscale, our knockback x flips its value to face the left as well
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            // Hit the target
            bool gotHit = damageable.Hit(attackDamage, deliveredKnockback);

            audioSource.PlayOneShot(hit1, hit1Volume);

        }
    }
}
