using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Slash : MonoBehaviour
{
    private Rigidbody2D rb;
    public int power = 4;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == null)
        {
            return;
        }
        if (collider.GetComponent<Health>() != null);
        {
            Health h = collider.GetComponent<Health>();
            if (h != null)
            {
                h.Damage(power, rb);
            }
        }
    }
}