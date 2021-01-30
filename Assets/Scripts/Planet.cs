using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Sprite planetSprite;
    public Collectible collectible;
    public Sprite collectibleSprite;


    private void OnSceneGUI()
    {
        collectible.GetComponent<SpriteRenderer>().sprite = collectibleSprite;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
