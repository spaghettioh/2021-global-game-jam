using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanetFinish : MonoBehaviour
{
    public UnityEvent onCollisionWithPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onCollisionWithPlayer.Invoke();
        }
    }
}
