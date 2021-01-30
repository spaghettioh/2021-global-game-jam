using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    public GameObject hero;
    public float radius;
    public float strengthOfAttraction;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius * transform.localScale.x * 2;
        strengthOfAttraction = (transform.localScale.x + transform.localScale.y) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity(hero.GetComponent<Rigidbody2D>());
    }

    private void ApplyGravity(Rigidbody2D p)
    {
        Vector3 offset = p.transform.position - transform.position;

        //we're doing 2d physics, so don't want to try and apply z forces!
        offset.z = 0;

        if (Mathf.Abs(offset.x) < radius && Mathf.Abs(offset.y) < radius)
        {
            p.AddForce(-strengthOfAttraction * offset.normalized, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
