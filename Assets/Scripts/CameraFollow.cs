using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Hero hero;
    // Update is called once per frame
    void Update()
    {
        transform.position = hero.gameObject.transform.position;
    }
}
