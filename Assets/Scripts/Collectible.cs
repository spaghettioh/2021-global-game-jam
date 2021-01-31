using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public Transform orbitAround;
    public float orbitSpeed;
    public UnityEvent collected;

    [HideInInspector]
    public Sprite collectibleSprite;

    private void Update()
    {
        if (orbitAround != null)
        {
            transform.RotateAround(orbitAround.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            collected.Invoke();

        }
    }

}
