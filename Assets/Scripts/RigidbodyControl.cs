using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyControl : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }

   public void RemoveContraints()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
