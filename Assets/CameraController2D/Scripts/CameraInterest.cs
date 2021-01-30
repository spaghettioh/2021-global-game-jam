using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Cinemachine;

public class CameraInterest : MonoBehaviour
{
    [Range(2, 100)]
    public float stealInterestRadius = 10f;
    [Range(1, 99)]
    public float stealFocusRadius = 5f;

    public Transform follow;

    Demo_HeroMover hero;
    // Start is called before the first frame update
    void Start()
    {
        hero = FindObjectOfType<Demo_HeroMover>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToCameraFollow = Vector2.Distance(transform.position, hero.transform.position);

        Vector3 focusPosition = new Vector3(transform.position.x, transform.position.y, -10);

        if (distanceToCameraFollow < stealFocusRadius)
        {
            // Lock the camera to the interest center when player is close
            follow.position = Vector3.Lerp(focusPosition, hero.transform.position, distanceToCameraFollow / stealFocusRadius); ;
        }
        else if (distanceToCameraFollow < stealInterestRadius)
        {
            // Gradually focus on the interest
            follow.position = Vector3.Lerp(focusPosition, hero.transform.position, distanceToCameraFollow / stealInterestRadius);
        }
        else
        {
            follow.position = hero.transform.position;
        }

    }
}
