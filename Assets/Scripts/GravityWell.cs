using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class GravityWell : MonoBehaviour
{
    public float gravity;
    public bool setStrengthBasedOnRadius = true;

    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D p = other.gameObject.GetComponent<Rigidbody2D>();
        Vector2 distance = p.transform.position - transform.position;

        if (other.gameObject.tag == "Player")
        {
            if (setStrengthBasedOnRadius)
            {
                gravity = GetComponent<CircleCollider2D>().radius;
            }

            p.AddForce(-gravity * distance.normalized, ForceMode2D.Force);
        }
    }
}
