using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [HideInInspector]
    public Sprite collectibleSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this);
    }

}
